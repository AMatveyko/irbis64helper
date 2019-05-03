using System;
using System.Collections.Generic;
using System.Text;
using irbis64helper.data.Model;

namespace irbis64helper.data
{
    public class IrbisDbClient : IDbClient
    {
        private bool _authorized = false;
        public bool Authorized
        {
            get => _authorized;
            private set => _authorized = value;
        }
        private DbInfo _dbInfo;
        public IrbisDbClient(DbConnectionInfo dbConnectionInfo)
        {
            _dbInfo = dbConnectionInfo.DbInfo;
        }
        public bool ContainByFields(Dictionary<string, string> fieldsValues)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetLockRecords()
        {
            throw new NotImplementedException();
        }

        private bool Login()
        {
            throw new NotImplementedException();
        }

        private bool Logout()
        {
            throw new NotImplementedException();
        }

        public string ReadRecord(string mfn)
        {
            throw new NotImplementedException();
        }

        public bool UnlockRecord(string mfn)
        {
            throw new NotImplementedException();
        }

        public bool UnlockRecords(IList<string> mfnList)
        {
            throw new NotImplementedException();
        }

        public bool WriteRecord(Record record)
        {
            throw new NotImplementedException();
        }
    }
}
