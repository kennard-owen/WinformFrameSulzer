using System;
using System.Text;
using System.IO;

namespace Common
{
    public static class Recordlog
    {
        private static object _obj = new object();

        private static bool _isRecord = true;
        private static string OutPutFolder;

        public static bool IsRecord
        {
            get { return Recordlog._isRecord; }
            set { Recordlog._isRecord = value; }
        }
        public static string LogPath
        {
            get
            {
                if (OutPutFolder == string.Empty)
                {
                    OutPutFolder = AppDomain.CurrentDomain.BaseDirectory;
                }
                return OutPutFolder;
            }
            set
            {
                OutPutFolder = value;
            }
        }
        public static void Write(string id, string log)
        {
            if (_isRecord)
            {
                lock (_obj)
                {
                    if (!Directory.Exists(OutPutFolder))
                    {
                        Directory.CreateDirectory(OutPutFolder);
                    }
                    string filePath = Path.Combine(OutPutFolder, "Log" + id + DateTime.Now.ToString("yyyy_MM_dd") + ".txt");
                    using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default))
                    {
                        sw.WriteLine(DateTime.Now.ToString());
                        sw.WriteLine(log);
                    }
                }
            }
        }

        public static void WriteError(string id, string log)
        {
            lock (_obj)
            {
                if (!Directory.Exists(OutPutFolder))
                {
                    Directory.CreateDirectory(OutPutFolder);
                }
                string filePath = Path.Combine(OutPutFolder, "Log" + id + DateTime.Now.ToString("yyyy_MM_dd") + ".txt");
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(log);
                }
            }
        }
    }
}
