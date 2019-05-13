using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    public class Record
    {
        public String MFN { get; set; }
        public String FIO
        {
            get
            {
                String fio = String.Empty;
                if (Fields.ContainsKey("10") && Fields["10"].Count > 0)
                    fio += Fields["10"][0];
                else
                    fio += "no name";
                if (Fields.ContainsKey("11") && Fields["11"].Count > 0)
                    fio += " " + Fields["11"][0];
                else
                    fio += " no fam";
                if (Fields.ContainsKey("12") && Fields["12"].Count > 0)
                    fio += " " + Fields["12"][0];
                return fio;
            }
        }
        public String Passport {
            get
            {
                if (Fields.ContainsKey("14") && Fields["14"].Count > 0)
                {
                    return Fields["14"][0];
                }
                else
                    return "NOT FOUND";
            }
        }
        public String DateOfBirth
        {
            get
            {
                if (Fields.ContainsKey("21") && Fields["21"].Count > 0)
                {
                    return Fields["21"][0];
                }
                else
                    return "NOTDATE";
            }
        }
        public Dictionary<String, List<String>> Fields { get; }
        public Record()
        {
            Fields = new Dictionary<String, List<String>>();
        }
        public void AddField(String field, String value)
        {
            if(!Fields.ContainsKey(field))
            {
                Fields.Add(field, new List<String>());
            }
            Fields[field].Add(value);
        }
    }
}
