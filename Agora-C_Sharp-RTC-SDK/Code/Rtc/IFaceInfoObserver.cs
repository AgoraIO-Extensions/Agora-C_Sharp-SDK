using System;
namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Facial information observer.
    /// 
    /// You can call RegisterFaceInfoObserver to register one IFaceInfoObserver observer.
    /// </summary>
    ///
    public abstract class IFaceInfoObserver
    {
        ///
        /// <summary>
        /// Occurs when the facial information processed by speech driven extension is received.
        /// </summary>
        ///
        /// <param name="outFaceInfo">
        /// Output parameter, the JSON string of the facial information processed by the voice driver plugin, including the following fields:
        /// faces: Object sequence. The collection of facial information, with each face corresponding to an object.
        /// blendshapes: Object. The collection of face capture coefficients, named according to ARkit standards, with each key-value pair representing a blendshape coefficient. The blendshape coefficient is a floating point number with a range of [0.0, 1.0].
        /// rotation: Object sequence. The rotation of the head, which includes the following three key-value pairs, with values as floating point numbers ranging from -180.0 to 180.0:
        /// pitch: Head pitch angle. A positve value means looking down, while a negative value means looking up.
        /// yaw: Head yaw angle. A positve value means turning left, while a negative value means turning right.
        /// roll: Head roll angle. A positve value means tilting to the right, while a negative value means tilting to the left.
        /// timestamp: String. The timestamp of the output result, in milliseconds. Here is an example of JSON:
        /// {
        /// "faces":[{
        /// "blendshapes":{
        /// "eyeBlinkLeft":0.9, "eyeLookDownLeft":0.0, "eyeLookInLeft":0.0, "eyeLookOutLeft":0.0, "eyeLookUpLeft":0.0,
        /// "eyeSquintLeft":0.0, "eyeWideLeft":0.0, "eyeBlinkRight":0.0, "eyeLookDownRight":0.0, "eyeLookInRight":0.0,
        /// "eyeLookOutRight":0.0, "eyeLookUpRight":0.0, "eyeSquintRight":0.0, "eyeWideRight":0.0, "jawForward":0.0,
        /// "jawLeft":0.0, "jawRight":0.0, "jawOpen":0.0, "mouthClose":0.0, "mouthFunnel":0.0, "mouthPucker":0.0,
        /// "mouthLeft":0.0, "mouthRight":0.0, "mouthSmileLeft":0.0, "mouthSmileRight":0.0, "mouthFrownLeft":0.0,
        /// "mouthFrownRight":0.0, "mouthDimpleLeft":0.0, "mouthDimpleRight":0.0, "mouthStretchLeft":0.0, "mouthStretchRight":0.0,
        /// "mouthRollLower":0.0, "mouthRollUpper":0.0, "mouthShrugLower":0.0, "mouthShrugUpper":0.0, "mouthPressLeft":0.0,
        /// "mouthPressRight":0.0, "mouthLowerDownLeft":0.0, "mouthLowerDownRight":0.0, "mouthUpperUpLeft":0.0, "mouthUpperUpRight":0.0,
        /// "browDownLeft":0.0, "browDownRight":0.0, "browInnerUp":0.0, "browOuterUpLeft":0.0, "browOuterUpRight":0.0,
        /// "cheekPuff":0.0, "cheekSquintLeft":0.0, "cheekSquintRight":0.0, "noseSneerLeft":0.0, "noseSneerRight":0.0,
        /// "tongueOut":0.0
        /// },
        /// "rotation":{"pitch":30.0, "yaw":25.5, "roll":-15.5},
        /// 
        /// }],
        /// "timestamp":"654879876546"
        /// }
        /// </param>
        ///
        /// <returns>
        /// true : Facial information JSON parsing successful. false : Facial information JSON parsing failed.
        /// </returns>
        ///
        public virtual bool OnFaceInfo(string outFaceInfo)
        {
            return true;
        }
    }
}
