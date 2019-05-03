using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    public class MessageEventArgs : EventArgs
    {
        public String Message { get; private set; }
        public MessageEventArgs(String message)
        {
            Message = message;
        }
    }
}
