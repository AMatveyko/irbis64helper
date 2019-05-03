using irbis64helper.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Tests.Model
{
    [TestClass]
    public class ResponseTests
    {
        [TestMethod]
        public void LoginResponse_ToString()
        {
            String[] splitedResponse = new string[]
            {
                "A",
                "1",
                "388456",
                "44",
                "64.2017.1",
                "",
                "",
                "",
                "",
                "",
                "-3337"
            };
            Response response = new Response();
            response.Command = splitedResponse[0];
            response.Seq = splitedResponse[1];
            response.Guid = splitedResponse[2];
            response.ReservStr4 = splitedResponse[3];
            response.ReservStr5 = splitedResponse[4];
            response.ReservStr6 = splitedResponse[5];
            response.ReservStr7 = splitedResponse[6];
            response.ReservStr8 = splitedResponse[7];
            response.ReservStr9 = splitedResponse[8];
            response.ReservStr10 = splitedResponse[9];
            response.Data = new PacketData();
            for (int i = 10; i < splitedResponse.Length; i++)
                response.Data.Rows.Add(splitedResponse[i]);
            String actual = response.ToString();

            String expected = "A\n1\n388456\n44\n64.2017.1\n\n\n\n\n\n-3337";

            Assert.AreEqual(expected, actual);
        }
    }
}
