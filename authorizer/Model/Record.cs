using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    public class Record
    {
        internal String MFN { get; set; }
        internal String Status { get; set; }
        internal String Version { get; private set; }
        internal Dictionary<String, List<String>> Fields { get; }
        internal Record()
        {
            Fields = new Dictionary<String, List<String>>();
        }
    }
}
