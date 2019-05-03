using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace irbis64helper.Data
{
    internal static class CreateRequest
    {
        internal static Request Login(String arm, String guid, String seq, PacketData packetData)
        {
            String command = "A";
            return Packet(command, arm, guid, seq, packetData);
        }
        internal static Request Logout(String arm, String guid, String seq, PacketData packetData)
        {
            String command = "B";
            return Packet(command, arm, guid, seq, packetData);
        }
        internal static Request Search(String arm, String guid, String seq, PacketData packetData)
        {
            String command = "K";
            return Packet(command, arm, guid, seq, packetData);
        }
        internal static Request ListLocked(String arm, String guid, String seq, PacketData packetData)
        {
            String command = "0";
            return Packet(command, arm, guid, seq, packetData);
        }
        internal static Request ReadRecord(String arm, String guid, String seq, PacketData packetData)
        {
            String command = "C";
            return Packet(command, arm, guid, seq, packetData);
        }
        internal static Request WriteRecord(String arm, String guid, String seq, PacketData packetData)
        {
            String command = "D";
            return Packet(command, arm, guid, seq, packetData);
        }
        private static Request Packet(String command, String arm, String guid, String seq, PacketData packetData)
        {
            Request request = new Request();
            request.Command = command;
            request.Arm = arm;
            request.Guid = guid;
            request.Seq = seq;
            request.Data = packetData;
            return request;
        }
    }
}
