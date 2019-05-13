using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace irbis64helper.Data
{
    internal static class CreateRecord
    {
        internal static Record GetRecord(RecordPacketData pData)
        {
            String[] rawFields = pData.Rows[1].Split(FieldSeparator.GetString, StringSplitOptions.RemoveEmptyEntries);
            Regex rAllFields = new Regex("^([0-9]{1,4})#(.*)");
            Regex firstData = new Regex("^([0-9]{1,10})#");
            Record record = new Record();
            Match m = firstData.Match(rawFields[0]);
            record.MFN = m.Groups[0].Value;
            for(int i = 1; i < rawFields.Length; i++)
            {
                m = rAllFields.Match(rawFields[i]);
                String field = m.Groups[1].Value;
                String value = m.Groups[2].Value;
                record.AddField(field, value);
            }
            return record;
        }
    }
}
