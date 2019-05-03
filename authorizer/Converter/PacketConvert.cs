using irbis64helper.Data;
using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Converter
{
    internal static class PacketConvert
    {
        internal static Response ByteToResponse(byte[] rawResponse)
        {
            String responseTostr = Encoding.UTF8.GetString(rawResponse);
            return CreateResponse.GetResponse(responseTostr);
        }
        internal static byte[] RequestToByte(Request request)
        {

            byte[] packetToByte = Encoding.UTF8.GetBytes(request.ToString());
            byte[] lengthPacket = Encoding.UTF8.GetBytes($"{packetToByte.Length}\n");
            byte[] finalPacket = new byte[lengthPacket.Length + packetToByte.Length];
            Array.Copy(lengthPacket, finalPacket, lengthPacket.Length);
            Array.Copy(packetToByte, 0, finalPacket, lengthPacket.Length, packetToByte.Length);
            return finalPacket;
        }
    }
}
