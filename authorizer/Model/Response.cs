using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    public class Response
    {
        internal String Command { get; set; }
        internal String Guid { get; set; }
        internal String Seq { get; set; }
        internal String ReservStr4 { get; set; } = "";
        internal String ReservStr5 { get; set; } = "";
        internal String ReservStr6 { get; set; } = "";
        internal String ReservStr7 { get; set; } = "";
        internal String ReservStr8 { get; set; } = "";
        internal String ReservStr9 { get; set; } = "";
        internal String ReservStr10 { get; set; } = "";
        internal PacketData Data { get; set; }

        public override string ToString()
        {
            return $"{Command}\n" +
                   $"{Seq}\n" +
                   $"{Guid}\n" +
                   $"{ReservStr4}\n" +
                   $"{ReservStr5}\n" +
                   $"{ReservStr6}\n" +
                   $"{ReservStr7}\n" +
                   $"{ReservStr8}\n" +
                   $"{ReservStr9}\n" +
                   $"{ReservStr10}\n" +
                    Data.ToString();
        }
    }
}
