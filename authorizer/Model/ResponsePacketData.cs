using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    internal class ResponsePacketData : PacketData
    {
        internal String ErrorCode { get => Rows[0]; }
    }
}
