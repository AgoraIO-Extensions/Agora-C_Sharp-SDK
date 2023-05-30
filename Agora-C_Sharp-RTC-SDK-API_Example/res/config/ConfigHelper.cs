using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace C_Sharp_API_Example
{
    public class ConfigHelper
    {
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key,
    string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        private string config_file_path_ = string.Empty;

        public ConfigHelper()
        {
            config_file_path_ = System.IO.Directory.GetCurrentDirectory() + "\\res\\config\\API_Example.ini";
            if (!File.Exists(config_file_path_))
            {
                MainForm.dump_handler_(config_file_path_ + " not Exists!!!!", -1);
            }
        }

        public void SetValue(string Section, string Key, string Value)
        {
            long OpStation = WritePrivateProfileString(Section, Key, Value, config_file_path_);
            if (OpStation == 0)
            {
                // fail
                string msg = "save " + Key + "/" + Value;
                MainForm.dump_handler_(msg, -1);
            }
        }

        public string GetValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, "", temp, 1024, config_file_path_);
            return temp.ToString();
        }

        public void OpenConfigFile()
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", config_file_path_);
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                System.Console.WriteLine(we.Message);
            }
        }
    }
}
