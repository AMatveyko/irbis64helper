using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Converter
{
    public static class StringBool
    {
        public static bool ZeroToBool(String str) => (str == "1") ? true : false;
    }
}
