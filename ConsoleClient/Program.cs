using irbis64helper.Auth;
using irbis64helper.Data;
using irbis64helper.Debug;
using irbis64helper.Model;
using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Message += DebugMeth;
            DbFieldsInfo dbFieldsInfo = new DbFieldsInfo();
            dbFieldsInfo.UNameField = "30";
            dbFieldsInfo.UPassField = "22";
            DbConnectionInfo dbConnectionInfo = new DbConnectionInfo("10.0.0.69", 6666, "RDR", "Wi-Fi", "Wi-Fi");
            IDbClient dbClient = new IrbisDbClient(dbConnectionInfo, dbFieldsInfo, true);
            IAuthHelper authHelper = new FreeRadiusHelper(dbClient, true);
            //Console.Write(authHelper.CheckAccount("10010", "1231"));
            authHelper.WriteAccountLoginInfo("10010", "10.1.1.1", "ff:ff:ff:ff:ff:ff", "fromscript");
        }
        private static void DebugMeth(object o, EventArgs e)
        {
            MessageEventArgs ev = e as MessageEventArgs;
            if (ev != null)
                Console.WriteLine(ev.Message);
        }
    }
}
