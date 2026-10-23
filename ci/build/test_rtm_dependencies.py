import unittest

from rtm_dependencies import from_results


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


if __name__ == "__main__":
    unittest.main()
