using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    internal static class FieldSeparator
    {
        internal static String GetString
        {
            get
            {
                return Encoding.UTF8.GetString(new byte[] { 31, 30 });
            }
        }
    }
}
