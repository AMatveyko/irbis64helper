using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace irbis64helper.Model
{
    public class Record
    {
        private Match _m;
        private Regex _r = new Regex(@"^\^a([0-9]{4})\^b([0-9]{6})\^c(.*)");
        public String MFN { get; set; }
        public String FIO
        {
            get
            {
                return $"{Surname} {Name} {Patronymic}";
            }
        }
        public String Patronymic
        {
            get
            {
                if (Fields.ContainsKey("12") && Fields["12"].Count > 0)
                    return Fields["12"][0];
                else
                    return "";
            }
        }
        public String Surname
        {
            get
            {
                if (Fields.ContainsKey("10") && Fields["10"].Count > 0)
                    return Fields["10"][0];
                else
                    return "no fam";
            }
        }
        public String Name
        {
            get
            {
                if (Fields.ContainsKey("11") && Fields["11"].Count > 0)
                    return Fields["11"][0];
                else
                    return "no name";
            }
        }
        public String Id
        {
            get
            {
                if (Fields.ContainsKey("30") && Fields["30"].Count > 0)
                    return Fields["30"][0];
                else
                    return "no Id";
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
        public String PassportSeria
        {
            get
            {
                if(_m == null)
                {
                    _m = _r.Match(Passport);
                }
                return _m.Groups[1].Value;
            }
        }
        public String PassportNumber
        {
            get
            {
                if (_m == null)
                {
                    _m = _r.Match(Passport);
                }
                return _m.Groups[2].Value;
            }
        }
        public String PassportOffice
        {
            get
            {
                if (_m == null)
                {
                    _m = _r.Match(Passport);
                }
                return _m.Groups[3].Value;
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
