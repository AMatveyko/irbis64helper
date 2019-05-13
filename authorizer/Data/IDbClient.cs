using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Data
{
    public interface IDbClient
    {
        //bool Authorized { get; }
        //bool ContainByFields(String uname, String upass);
        //bool UnlockRecords(IList<String> mfnList);
        //bool UnlockRecord(String mfn);
        //IList<String> GetLockRecords();
        //string ReadRecord(string mfn);
        //bool WriteRecord(Record record);
        Response Login();
        Response FindReader(String idRdr);
        Response FindReader(String idRdr, String pwdRdr);
        Response ReadRecord(String mfn);
        Response WriteRecord(String mfn, String record);
        Record GetRecordById(String rdrId);
    }
}
