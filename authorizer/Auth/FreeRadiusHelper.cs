using irbis64helper.Data;
using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Auth
{
    public class FreeRadiusHelper : IAuthHelper
    {

        private IDbClient _db;

        private bool _debug;

        public FreeRadiusHelper(IDbClient dbClient, bool debug = false)
        {
            _debug = debug;
            _db = dbClient;
        }
        public string CheckAccount(string rdrId, string rdrPwd)
        {
            bool result = false;
            Response response = _db.Login();
            if (CheckResponse.ErrorCode(response))
            {
                response = _db.FindReader(rdrId, rdrPwd);
                if (CheckResponse.ErrorCode(response))
                {
                    result = CheckResponse.ContainRdr(response);
                }
            }
            return result ? "Accept" : "Reject";
        }

        public void WriteAccountLoginInfo(string idRdr, string ipAddr, string macAddr, string calledStation)
        {
            String date;
            String time;
            Date.GetDateTime(out date, out time);
            String value = $"^X{ipAddr}^D{date}^CWi_Fi(Вход)^V{calledStation}^U{macAddr}^1{time}^2{time}";
            WriteAccountInfo(idRdr, value);
        }

        public void WriteAccountLogoutInfo(string idRdr, string sessionTime, string inputByte, string outputByte)
        {
            String date;
            String time;
            Date.GetDateTime(out date, out time);
            String value = $"^D{date}^CWi_Fi(Выход) {sessionTime}^1{time}^2{time}";
            WriteAccountInfo(idRdr, value);
        }
        private void WriteAccountInfo(String idRdr, String value)
        {
            String fieldNumber = "40";
            Response response = _db.Login();
            if (CheckResponse.ErrorCode(response))
            {
                response = _db.FindReader(idRdr);
                SearchPacketData packetData = (SearchPacketData)response.Data;
                String mfn = packetData.GetMfn();
                response = _db.ReadRecord(mfn);
                EditRecord.AddField(ref response, fieldNumber, value);
                response = _db.WriteRecord(mfn, response.Data.Rows[1]);
            }
        }
    }
}
