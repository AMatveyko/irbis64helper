using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.data.Model
{
    public class DbConnectionInfo
    {
        internal ConnectionInfo ConnectionInfo { get; private set; }
        internal DbInfo DbInfo { get; private set; }

        public DbConnectionInfo(String host, String port, String dbName, String userName, String password)
        {
            ConnectionInfo = new ConnectionInfo(host, port);
            DbInfo = new DbInfo(dbName, userName, password);
        }
    }
}
