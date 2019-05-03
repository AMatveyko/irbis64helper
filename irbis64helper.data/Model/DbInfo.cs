using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.data.Model
{
    internal class DbInfo
    {
        internal String DbName { get; private set; }
        internal String UserName { get; private set; }
        internal String Password { get; private set; }
        internal DbInfo(String dbName, String userName, String password)
        {
            DbName = dbName;
            UserName = userName;
            Password = password;
        }
    }
}
