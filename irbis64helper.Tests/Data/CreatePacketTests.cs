using System;
using System.Collections.Generic;
using System.Text;
using irbis64helper.Data;
using irbis64helper.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace irbis64helper.Tests.Data
{
    [TestClass]
    public class CreatePacketTests
    {
        [TestMethod]

        public void ResponseLogin_createResponse()
        {
            String expected = "A\nC\nA\n1\n388456\n\n\n\n\n\nWi-Fi\nWi-Fi";
            PacketData packetData = new PacketData($"Wi-Fi\nWi-Fi");
            Request request = CreateRequest.Login("C", "388456", "1", packetData);
            String actual = request.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
