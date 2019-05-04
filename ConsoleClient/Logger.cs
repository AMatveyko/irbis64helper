using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClient
{
    internal static class Logger
    {
        private static String _fileName = "message.log";
        internal static void WriteLog(String logMessage)
        {
            String endlineAdded = $"{logMessage}\n";
            byte[] buff = Encoding.Default.GetBytes(endlineAdded);
            _fileName = AppDomain.CurrentDomain.BaseDirectory + _fileName;
            using (FileStream fs = new FileStream(_fileName, FileMode.Append, FileAccess.Write))
            {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
                fs.Close();
            }
        }
    }
}
