using System;
using System.IO;

namespace HappyDummyWFA
{
    class Utils
    {
		public static string CreateLog(string value, string filename, string browsedLogPath)
        {
            string homePath = "";
            string flagLog = "HappyDummyLogs";

            if (string.IsNullOrEmpty(browsedLogPath) || browsedLogPath.Equals("C:\\"))
            {
                if (!File.Exists(homePath))
                {
                    homePath = "C:\\Users" + "\\" + Environment.UserName + "\\" + Environment.SpecialFolder.Desktop + "\\" + flagLog;

                    if (!Directory.Exists(homePath))
                    {
                        Directory.CreateDirectory(homePath);
                    }
                    homePath += "\\" + filename + ".txt";
                }
            }
            else
            {
                homePath = browsedLogPath + "\\" + filename + ".txt";
            }


            var tw = new StreamWriter(homePath, true);
            tw.WriteLine(value);
            tw.Close();

            return homePath;
        }

        public static int GetTimeInterval(Random r)
        {
            return r.Next(2, 14);
        }

    }

}
