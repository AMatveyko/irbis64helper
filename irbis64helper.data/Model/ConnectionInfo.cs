using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.data.Model
{
    internal class ConnectionInfo
    {
        internal string Host { get; private set; }
        internal string Port { get; private set; }
        internal ConnectionInfo(String host, String port)
        {
            Host = host;
            Port = port;
        }
    }
}
