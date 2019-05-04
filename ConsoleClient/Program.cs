using irbis64helper.Auth;
using irbis64helper.Converter;
using irbis64helper.Data;
using irbis64helper.Logger;
using irbis64helper.Model;
using System;

namespace ConsoleClient
{
    class Program
    {

        private static String accessExample = "dotnet name.dll access readerId readerWiFiPwd";
        private static String writeLoginExample = "dotnet name.dll writelogin 007000-91 1.1.1.1 FF:FF:FF:FF:FF:FF clientIdent";
        private static String writeLogoutExample = "dotnet name.dll writelogout 007000-91 60 2048 1024";

        private static IAuthHelper _authHelper;

        static void Main(string[] args)
        {

            Parameters parameters;
            ReadConfig.GetParameters(out parameters);

            Say.Message += DebugMeth;
            DbFieldsInfo dbFieldsInfo = new DbFieldsInfo();
            dbFieldsInfo.UNameField = parameters.GetNameFieldNumber();
            dbFieldsInfo.UPassField = parameters.GetPwdFieldNumber();
            String host = parameters.GetHost().ToString();
            int port = parameters.GetPort();
            String db = parameters.GetDbName();
            String uname = parameters.GetUserName();
            String pawd = parameters.GetPassword();
            Boolean debug = StringBool.ZeroToBool( parameters.GetDebug() );
            DbConnectionInfo dbConnectionInfo = new DbConnectionInfo(host, port, db, uname, pawd);
            IDbClient dbClient = new IrbisDbClient(dbConnectionInfo, dbFieldsInfo, debug);
            _authHelper = new FreeRadiusHelper(dbClient, debug);

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "access":
                        {
                            if (args.Length == 3)
                                Access(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(accessExample);
                            }
                            break;
                        }
                    case "writelogin":
                        {
                            if (args.Length == 5)
                                WriteLogin(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(writeLoginExample);
                            }
                            break;
                        }
                    case "writelogout":
                        {
                            if (args.Length == 5)
                                WriteLogout(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(writeLogoutExample);
                            }
                            break;
                        }
                    default:
                        Help();
                        break;
                }
            }
            else
            {
                Help();
            }

            //Console.Write(authHelper.CheckAccount("10010", "1231"));
            //_authHelper.WriteAccountLoginInfo("10010", "10.1.1.1", "ff:ff:ff:ff:ff:ff", "fromscript");
            //_authHelper.WriteAccountLoginInfo("10010", "10.1.1.1", "ff:ff:ff:ff:ff:ff", "fromscript");
        }
        private static void Access(String[] args)
        {
            String rdrId = args[1];
            String rdrPwd = args[2];
            String result = _authHelper.CheckAccount(rdrId, rdrPwd);
            Console.Write(result);
            Logger.WriteLog($"{args[1]}@{args[2]}: {result}");
        }
        private static void WriteLogin(String[] args)
        {
            String rdrId = args[1];
            String ipAddr = args[2];
            String macAddr = args[3];
            String calledStation = args[4];
            Logger.WriteLog($"Start: {rdrId} {ipAddr} {macAddr} {calledStation}");
            _authHelper.WriteAccountLoginInfo(rdrId, ipAddr, macAddr, calledStation);
        }
        private static void WriteLogout(String[] args)
        {
            String rdrId = args[1];
            String sessionTime = args[2];
            String inputBytes = args[3];
            String outputBytes = args[4];
            Logger.WriteLog($"Stop: {rdrId}, Time {sessionTime}second, input {inputBytes}, output {outputBytes}");
            _authHelper.WriteAccountLogoutInfo(rdrId, sessionTime, inputBytes, outputBytes);
        }
        private static void Help()
        {
            Console.WriteLine("Examples:");
            Console.WriteLine(accessExample);
            Console.WriteLine(writeLoginExample);
            Console.WriteLine(writeLogoutExample);
        }
        private static void DebugMeth(object o, EventArgs e)
        {
            MessageEventArgs ev = e as MessageEventArgs;
            if (ev != null)
                Console.WriteLine(ev.Message);
        }
    }
}

