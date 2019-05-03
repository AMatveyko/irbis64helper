using irbis64helper.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Tests.Model
{
    [TestClass]
    public class PacketDataTests
    {
        [TestMethod]
        public void PacketData_RequestCtor_ToString()
        {
            PacketData packetData = new PacketData("Wi-Fi\nWi-Fi");
            String expected = "Wi-Fi\nWi-Fi";
            String actual = packetData.ToString();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PacketData_Response_ToString()
        {
            PacketData packetData = new PacketData();
            String[] rows = new String[] { "-3337" };
            foreach (var row in rows)
                packetData.Rows.Add(row);
            String actual = packetData.ToString();

            String expected = "-3337";

            Assert.AreEqual(expected, actual);
        }
    }
}
