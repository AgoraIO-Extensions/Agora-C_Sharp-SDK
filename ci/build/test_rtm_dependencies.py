import unittest

from rtm_dependencies import from_results, validate_url


class RtmDependenciesTest(unittest.TestCase):
    def inputs(self):
        return [{"platform": p, "product_type": "rtm",
                 "cdn": [f"https://download.shengwang.cn/sdk/release/Shengwang_Native_SDK_for_{p}_MINI_RTM_123.zip"],
                 "iris_cdn": [f"https://download.agora.io/sdk/release/iris_2.3.1-dev.4_RTM_{p}_Video_{'Unity' if p == 'Mac' else 'Standalone'}_123.zip"]}
                for p in ("Android", "iOS", "Mac", "Windows")]

    def test_complete_rtm_and_no_rtc_fallback(self):
        values = self.inputs()
        self.assertEqual(len(from_results(values)), 8)
        values[2]["iris_cdn"][0] = values[2]["iris_cdn"][0].replace("Unity", "Standalone")
        with self.assertRaises(ValueError):
            from_results(values)

    def test_reject_rtc_ambiguous_and_untrusted(self):
        for change in (lambda v: v[0].update(product_type="rtc"),
                       lambda v: v[0]["cdn"].append(v[0]["cdn"][0].replace("123", "456")),
                       lambda v: v[0]["cdn"].__setitem__(0, v[0]["cdn"][0] + "?token=private")):
            values = self.inputs()
            change(values)
            with self.assertRaises(ValueError):
                from_results(values)

    def test_published_native_zip_and_platform_identity(self):
        values = self.inputs()
        values[0]["cdn"][0] = "https://download.shengwang.cn/sdk/release/ShengwangRtmEngine_Android_Preview_2.3.1-dev.4_Video_20261022_034607.zip"
        self.assertEqual(len(from_results(values)), 8)
        values[0]["cdn"][0] = values[0]["cdn"][0].replace("download.shengwang.cn", "unapproved.invalid")
        with self.assertRaises(ValueError):
            from_results(values)
        values = self.inputs()
        values[0]["cdn"][0] = values[0]["cdn"][0].replace("_Android_", "_iOS_")
        with self.assertRaises(ValueError):
            from_results(values)

    def test_official_native_names_and_unity_iris_selection(self):
        values = self.inputs()
        native = {
            "Android": "Agora_RTM_JAVA_SDK_for_Android_v2.3.1.zip",
            "Windows": "Agora_RTM_C%2B%2B_SDK_for_Windows_v2.3.1.zip",
            "iOS": "Agora_RTM_OC_SDK_v2.3.1.zip",
            "Mac": "Agora_RTM_OC_SDK_v2.3.1.zip",
        }
        for item in values:
            item["cdn"] = ["https://download.agora.io/rtm2/release/" + native[item["platform"]]]
            item["iris_cdn"][0] = item["iris_cdn"][0].replace("2.3.1-dev.4", "2.3.1")
        selected = from_results(values)
        self.assertEqual(len(selected), 8)
        self.assertEqual(selected["NATIVE_IOS_URL"], selected["NATIVE_MAC_URL"])
        with self.assertRaises(ValueError):
            validate_url(selected["NATIVE_ANDROID_URL"], "IOS", False)
        with self.assertRaises(ValueError):
            validate_url(selected["NATIVE_IOS_URL"], "ANDROID", False)
        with self.assertRaises(ValueError):
            validate_url(selected["NATIVE_WIN_URL"] + "?token=private", "WIN", False)
        with self.assertRaises(ValueError):
            validate_url(selected["NATIVE_IOS_URL"], "IOS", True)


if __name__ == "__main__":
    unittest.main()
