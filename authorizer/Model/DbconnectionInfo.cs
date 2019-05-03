using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    public class DbConnectionInfo
    {
        internal ConnectionInfo ConnectionInfo { get; private set; }
        internal DbInfo DbInfo { get; private set; }

        public DbConnectionInfo(String host, Int32 port, String dbName, String userName, String password)
        {
            ConnectionInfo = new ConnectionInfo(host, port);
            DbInfo = new DbInfo(dbName, userName, password);
        }
    }
}
