using irbis64helper.Converter;
using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Data
{
    internal static class CheckResponse
    {
        internal static bool ErrorCode(Response response)
        {
            ResponsePacketData packetData = response.Data as ResponsePacketData;
            if (packetData != null)
            {
                if ((packetData.ErrorCode == "0") || (packetData.ErrorCode == "-3337"))
                {
                    return true;
                }
                else
                {
                    Debug.Debug.PutError(Model.ErrorCode.GetErrorValue(packetData.ErrorCode));
                    return false;
                }
            }
            else
            {
                Debug.Debug.PutError("PacketData not a ResponsePacketData!!!");
                return false;
            }
        }
        internal static bool ContainRdr(Response response)
        {
            SearchPacketData packetData = response.Data as SearchPacketData;
            if (packetData != null)
            {
                return StringBool.ZeroToBool(packetData.Contain);
            }
            else
            {
                Debug.Debug.PutError("PacketData not a SearchPacketData!!!");
                return false;
            }
        }
    }
}
