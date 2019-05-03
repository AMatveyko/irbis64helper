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

        public bool WriteAccountLoginInfo(string idRdr, string ipAddr, string macAddr, string calledStation)
        {
            bool result = false;
            Response response = _db.Login();
            if(CheckResponse.ErrorCode(response))
            {
                response = _db.FindReader(idRdr);
                SearchPacketData packetData = (SearchPacketData)response.Data;
                String mfn = packetData.GetMfn();
                response = _db.ReadRecord(mfn);
                String separatorStr = Encoding.UTF8.GetString(new byte[] { 31, 30 });
                response.Data.Rows[1] += separatorStr + "40#^X172.16.11.200^D20190423^CWi_Fi(dfsdf)^VTestTestTest^U2C:57:31:6E:F9:C0^1195038^2195038";
                response = _db.WriteRecord(mfn, response.Data.Rows[1]);

            }
            return true;
        }

        public bool WriteAccountLogoutInfo(string idRdr, string sessionTime, string inputByte, string outputByte)
        {
            throw new NotImplementedException();
        }
    }
}
