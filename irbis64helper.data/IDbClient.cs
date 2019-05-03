using irbis64helper.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.data
{
    public interface IDbClient
    {
        bool Authorized { get; }
        bool ContainByFields(Dictionary<string, string> fieldsValues);
        bool UnlockRecords(IList<String> mfnList);
        bool UnlockRecord(String mfn);
        IList<String> GetLockRecords();
        string ReadRecord(string mfn);
        bool WriteRecord(Record record);
    }
}
