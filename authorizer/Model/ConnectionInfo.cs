using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    internal class ConnectionInfo
    {
        internal string Host { get; private set; }
        internal int Port { get; private set; }
        internal ConnectionInfo(String host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
