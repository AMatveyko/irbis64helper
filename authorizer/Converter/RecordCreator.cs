using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Converter
{
    internal static class RecordCreator
    {
        internal static Record GetRecord(RecordPacketData dataRecord)
        {
            Record record = new Record();
            record.MFN = (dataRecord.Rows[1].Split('#'))[0];
            record.Status = (dataRecord.Rows[2].Split('#'))[1];
            for (int i = 3; i < dataRecord.Rows.Count; i++)
            {
                String[] fieldPair = dataRecord.Rows[i].Split('#');
                if (fieldPair.Length == 2)
                {
                    if (record.Fields.ContainsKey(fieldPair[0]))
                        record.Fields[fieldPair[0]].Add(fieldPair[1]);
                    else
                    {
                        record.Fields.Add(fieldPair[0], new List<String>());
                        record.Fields[fieldPair[0]].Add(fieldPair[1]);
                    }
                }
            }
            return record;
        }
        internal static Record AddField(Record record, String fieldNumber, String value)
        {
            if(record.Fields.ContainsKey(fieldNumber))
            {
                record.Fields[fieldNumber].Add(value);
            }
            else
            {
                record.Fields.Add(fieldNumber, new List<string>());
                record.Fields[fieldNumber].Add(value);
            }
            return record;
        }
    }
}
