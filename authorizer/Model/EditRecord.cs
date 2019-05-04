using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    internal static class EditRecord
    {
        internal static void AddField(ref Response response, String fieldNumber, String value)
        {
            if(response.Data is RecordPacketData)
            {
                response.Data.Rows[1] += $"{FieldSeparator.GetString}{fieldNumber}#{value}";
            }
            else
            {
                Logger.Say.PutError("EditRecord.AddField: response.Data not RecordPacketData.");
            }
        }
    }
}
