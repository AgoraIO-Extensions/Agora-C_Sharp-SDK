using System;
using System.Collections;
using Agora.Rtc;
using Agora.Rtc.LitJson;

// Runs against the real SDK after regeneration, without requiring a camera or Native SDK.
internal static class CameraConfigurationChecks
{
    private static void Check(bool condition, string message)
    {
        if (!condition) throw new Exception(message);
    }

    private static Optional<T> Selected<T>(T value)
    {
        var optional = new Optional<T>();
        optional.SetValue(value);
        return optional;
    }

    private static void CheckUnset(CameraCapturerConfiguration configuration)
    {
        Check(!configuration.allowAutoMacroSwitching.HasValue(), "legacy camera constructor must leave auto macro unset");
        var json = JsonMapper.ToObject(JsonMapper.ToJson(configuration));
        Check(!((IDictionary)json).Contains("allowAutoMacroSwitching"), "unset auto macro must be omitted from JSON");
    }

    internal static void Run()
    {
        var direction = Selected((CAMERA_DIRECTION)1);
        var focalLength = Selected((CAMERA_FOCAL_LENGTH_TYPE)0);
        var deviceId = Selected("camera-device");
        var cameraId = Selected("camera-id");
        var followRatio = Selected(false);
        var format = new VideoFormat(640, 480, 30);

        // This call is also a source compatibility check for pre-4.5.3.10 clients.
        var legacy = new CameraCapturerConfiguration(
            cameraDirection: direction, cameraFocalLengthType: focalLength,
            deviceId: deviceId, cameraId: cameraId,
            followEncodeDimensionRatio: followRatio, format: format);
        CheckUnset(legacy);
        Check(legacy.cameraDirection.GetValue() == direction.GetValue()
            && legacy.cameraFocalLengthType.GetValue() == focalLength.GetValue()
            && legacy.deviceId.GetValue() == "camera-device"
            && legacy.cameraId.GetValue() == "camera-id"
            && !legacy.followEncodeDimensionRatio.GetValue()
            && Object.ReferenceEquals(legacy.format, format), "legacy camera arguments must be preserved");

        // Binary callers need the exact old metadata signature, not an optional seventh parameter.
        var constructor = typeof(CameraCapturerConfiguration).GetConstructor(new[] {
            typeof(Optional<CAMERA_DIRECTION>), typeof(Optional<CAMERA_FOCAL_LENGTH_TYPE>),
            typeof(Optional<string>), typeof(Optional<string>), typeof(Optional<bool>), typeof(VideoFormat)
        });
        Check(constructor != null, "six-parameter camera constructor metadata must remain available");
        CheckUnset((CameraCapturerConfiguration)constructor.Invoke(new object[] {
            direction, focalLength, deviceId, cameraId, followRatio, format
        }));
        CheckUnset(new CameraCapturerConfiguration());

        foreach (var enabled in new[] { false, true })
        {
            var configuration = new CameraCapturerConfiguration(direction, focalLength,
                deviceId, cameraId, followRatio, format, Selected(enabled));
            var json = JsonMapper.ToObject(JsonMapper.ToJson(configuration));
            Check(configuration.allowAutoMacroSwitching.HasValue()
                && configuration.allowAutoMacroSwitching.GetValue() == enabled,
                "explicit auto macro value must be preserved");
            Check(((IDictionary)json).Contains("allowAutoMacroSwitching")
                && (bool)json["allowAutoMacroSwitching"] == enabled,
                "both explicit true and false auto macro values must serialize");
        }
        Console.WriteLine("Camera constructor and optional JSON regressions passed.");
    }
}
