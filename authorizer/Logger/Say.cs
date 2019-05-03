using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Logger
{
    public static class Say
    {
        public static event EventHandler Message;
        internal static void PutError(String message)
        {
            String modMessage = $"Error: {message}";
            Invoke(modMessage);
        }
        internal static void PutDebug(String message)
        {
            String modMessage = $"Debug message:\n{message}|<-End Debug message.";
            Invoke(modMessage);
        }
        internal static void PutDebugToConsole(String message)
        {
            String modMessage = "Debug message:\n" + message + "|<-End Debug message.";
            Console.WriteLine(modMessage);
        }
        private static void Invoke(String message)
        {
            MessageEventArgs args = new MessageEventArgs(message);
            Message?.Invoke(null, args);
        }
    }
}
