using irbis64helper.Converter;
using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace irbis64helper.Data
{
    internal class Connection
    {
        private Socket _socket;
        private ConnectionInfo _connectionInfo;
        private int _buffer = 512;
        private bool _debug;

        internal Connection(ConnectionInfo connectionInfo, bool debug = false)
        {
            _connectionInfo = connectionInfo;
            _debug = debug;
        }

        internal Response SendRequestAndGetResponse(Request request)
        {
            if (_debug)
                Logger.Say.PutDebug($"Request: \n{request.ToString()}");
            SendPacket(request);
            Response response = GetAnswer();
            if (_debug)
                Logger.Say.PutDebug($"Response: \n{response.ToString()}");
            return response;
        }
        private void SendPacket(Request request)
        {
            byte[] requestPkt = PacketConvert.RequestToByte(request);
            Connect();
            _socket.Send(requestPkt);
        }

        private Response GetAnswer()
        {
            List<byte> data = new List<byte>();
            int receive = _buffer;
            while (receive > 0)
            {
                byte[] buffer = new byte[_buffer];
                receive = _socket.Receive(buffer);
                if (receive == _buffer)
                    data.AddRange(buffer);
                else
                    //for (int i = 0; i < receive; i++) (OLD)
                    for (int i = 0; i < receive; i++)
                        data.Add(buffer[i]);
            }
            byte[] dataArr = data.ToArray();
            Disconnect();
            Response response = PacketConvert.ByteToResponse(dataArr);
            return response;
        }

        private bool Connect()
        {
            Boolean result;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect(_connectionInfo.Host, _connectionInfo.Port);
                result = true;
            }
            catch (Exception e)
            {
                Logger.Say.PutError(e.Message);
                result = false;
            }
            return result;
        }
        private bool Disconnect()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            return true;
        }

    }
}
