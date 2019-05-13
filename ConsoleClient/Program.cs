using irbis64helper.Auth;
using irbis64helper.Converter;
using irbis64helper.Data;
using irbis64helper.Logger;
using irbis64helper.Model;
using System.Collections.Generic;
using System;

namespace ConsoleClient
{
    class Program
    {

        private enum Examples
        {
            ACCESS,
            LOGINDB,
            LOGOUTDB,
            LOGINCSV,
            LOGOUTCSV
        };

        private static Dictionary<Examples, String> _examples = new Dictionary<Examples, String>()
        {
            { Examples.ACCESS,    "dotnet name.dll access readerId readerWiFiPwd" },
            { Examples.LOGINDB,   "dotnet name.dll loginToDb 007000-91 1.1.1.1 FF:FF:FF:FF:FF:FF clientIdent" },
            { Examples.LOGOUTDB,  "dotnet name.dll logoutToDb 007000-91 60 2048 1024" },
            { Examples.LOGINCSV,  "dotnet name.dll loginToCsv 007000-91 1.1.1.1 FF:FF:FF:FF:FF:FF clientIdent" },
            { Examples.LOGOUTCSV, "dotnet name.dll logoutToCsv 007000-91 1.1.1.1 FF:FF:FF:FF:FF:FF clientIdent 60" }
        };

        private static IAuthHelper _authHelper;
        private static IDbClient _dbClient;

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
            Boolean debug = StringBool.ZeroToBool(parameters.GetDebug());
            DbConnectionInfo dbConnectionInfo = new DbConnectionInfo(host, port, db, uname, pawd);
            _dbClient = new IrbisDbClient(dbConnectionInfo, dbFieldsInfo, debug);
            _authHelper = new FreeRadiusHelper(_dbClient, debug);

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
                                Console.WriteLine(_examples[Examples.ACCESS]);
                            }
                            break;
                        }
                    case "loginToDb":
                        {
                            if (args.Length == 5)
                                LoginToDb(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(_examples[Examples.LOGINDB]);
                            }
                            break;
                        }
                    case "logoutToDb":
                        {
                            if (args.Length == 5)
                                LogoutToDb(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(_examples[Examples.LOGOUTDB]);
                            }
                            break;
                        }
                    case "loginToCsv":
                        {
                            if (args.Length == 5)
                                LoginToCsv(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(_examples[Examples.LOGINCSV]);
                            }
                            break;
                        }
                    case "logoutToCsv":
                        {
                            if (args.Length == 6)
                                LogoutToCsv(args);
                            else
                            {
                                Console.WriteLine("Error args!!! Example:");
                                Console.WriteLine(_examples[Examples.LOGOUTCSV]);
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
        private static void LoginToDb(String[] args)
        {
            String rdrId = args[1];
            String ipAddr = args[2];
            String macAddr = args[3];
            String calledStation = args[4];
            Logger.WriteLog($"Start: {rdrId} {ipAddr} {macAddr} {calledStation}");
            _authHelper.WriteAccountLoginInfo(rdrId, ipAddr, macAddr, calledStation);
        }
        private static void LogoutToDb(String[] args)
        {
            String rdrId = args[1];
            String sessionTime = args[2];
            String inputBytes = args[3];
            String outputBytes = args[4];
            Logger.WriteLog($"Stop: {rdrId}, Time {sessionTime} sec, input {inputBytes}, output {outputBytes}");
            _authHelper.WriteAccountLogoutInfo(rdrId, sessionTime, inputBytes, outputBytes);
        }
        private static void LoginToCsv(String[] args)
        {
            String rdrId = args[1];
            String ipAddr = args[2];
            String macAddr = args[3];
            String calledStation = args[4];
            Logger.WriteLog($"Start: {rdrId} {ipAddr} {macAddr} {calledStation}");
            Record record = _dbClient.GetRecordById(rdrId);
            String[] values = CreateValuesForCsv("Вход", ipAddr, macAddr, "0", record);
            SaveToCsv.Save(calledStation, values);
        }
        private static void LogoutToCsv(String[] args)
        {
            String rdrId = args[1];
            String ipAddr = args[2];
            String macAddr = args[3];
            String calledStation = args[4];
            String sessionTime = args[5];
            Logger.WriteLog($"Stop: {rdrId}, Time {sessionTime} sec");
            Record record = _dbClient.GetRecordById(rdrId);
            String[] values = CreateValuesForCsv("Выход", ipAddr, macAddr, sessionTime, record);
            SaveToCsv.Save(calledStation, values);
        }
        private static String[] CreateValuesForCsv(String events, String ip, String mac, String sessionTime, Record record)
        {
            String[] newValues = new string[]
            {
                events,
                record.Id,
                record.Surname,
                record.Name,
                record.Patronymic,
                record.DateOfBirth,
                record.PassportSeria,
                record.PassportNumber,
                record.PassportOffice,
                mac,
                ip,
                sessionTime
            };
            return newValues;
        }

        private static void Help()
        {
            Console.WriteLine("Examples:");
            foreach(var example in _examples)
            {
                Console.WriteLine(example.Value);
            }
        }
        private static void DebugMeth(object o, EventArgs e)
        {
            MessageEventArgs ev = e as MessageEventArgs;
            if (ev != null)
                Console.WriteLine(ev.Message);
        }
    }
}

