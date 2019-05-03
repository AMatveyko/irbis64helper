using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    internal class Request
    {
        internal String Command { get; set; }
        internal String Arm { get; set; }
        internal String Guid { get; set; }
        internal String Seq { get; set; }
        internal String UserPass { get; set; } = "";
        internal String UserName { get; set; } = "";
        internal String ReservStr8  { get; } = "";
        internal String ReservStr9  { get; } = "";
        internal String ReservStr10 { get; } = "";
        internal PacketData Data { get; set; }

        public override string ToString()
        {
            return $"{Command}\n" +
                   $"{Arm}\n" +
                   $"{Command}\n" +
                   $"{Guid}\n" +
                   $"{Seq}\n" +
                   $"{UserPass}\n" +
                   $"{UserName}\n" +
                   $"{ReservStr8}\n" +
                   $"{ReservStr9}\n" +
                   $"{ReservStr10}\n" +
                    Data.ToString();
        }
    }
}
