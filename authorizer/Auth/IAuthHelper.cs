using irbis64helper.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Auth
{
    public interface IAuthHelper
    {
        string CheckAccount(String rdrId, String rdrPwd);
        bool WriteAccountLoginInfo(String idRdr, String ipAddr, String macAddr, String calledStation);
        bool WriteAccountLogoutInfo(String idRdr, String sessionTime, String inputByte, String outputByte);
    }
}
