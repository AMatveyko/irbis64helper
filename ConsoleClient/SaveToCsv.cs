using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleClient
{
    internal static class SaveToCsv
    {
        internal static void Save(String hotspotName, String[] values)
        {
            String dirPath = $"{AppDomain.CurrentDomain.BaseDirectory}logs/{hotspotName}";
            Dictionary(dirPath);
            String filePath = $"{dirPath}//{GetFileName()}.csv";
            String str = $"{GetDateTime()},{MakeString(values)}\n";
            byte[] buff = Encoding.UTF8.GetBytes(str);
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
                fs.Close();
            }
        }
        private static String MakeString(String[] values)
        {
            String str = String.Empty;
            foreach(var item in values)
            {
                str += $"{item},";
            }
            return str.TrimEnd(',');
        }
        private static void Dictionary(String dictPath)
        {
            bool exist = System.IO.Directory.Exists(dictPath);
            if (!exist)
            {
                System.IO.Directory.CreateDirectory(dictPath);
            }
        }
        private static String GetFileName()
        {
            return DateTime.Now.ToString("yyyy-MMMM-dd"); ;
        }
        private static String GetDateTime()
        {
            return DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
        }
    }
}
