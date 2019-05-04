using irbis64helper.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Auth
{
    public interface IAuthHelper
    {
        string CheckAccount(String rdrId, String rdrPwd);
        void WriteAccountLoginInfo(String idRdr, String ipAddr, String macAddr, String calledStation);
        void WriteAccountLogoutInfo(String idRdr, String sessionTime, String inputByte, String outputByte);
    }
}
