using irbis64helper.Auth;
using irbis64helper.Data;
using irbis64helper.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Tests.Auth
{
    [TestClass]
    public class FreeRadiusAuthHelperTests
    {
        [TestMethod]
        public void CheckAccount_10010_1231_Accept()
        {
            String expected = "Accept";
            DbConnectionInfo dbConnectionInfo = new DbConnectionInfo("10.0.0.70", 6666, "RDR", "Wi-Fi", "Wi-Fi");
            DbFieldsInfo dbFieldsInfo = new DbFieldsInfo() { UNameField = "30", UPassField = "22" };
            IDbClient dbClient = new IrbisDbClient(dbConnectionInfo, dbFieldsInfo);
            IAuthHelper freeRadiusAuthHelper = new FreeRadiusHelper(dbClient);

            String actual = freeRadiusAuthHelper.CheckAccount("10010", "1231");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckAccount_10010_1231_Reject()
        {
            String expected = "Reject";
            DbConnectionInfo dbConnectionInfo = new DbConnectionInfo("10.0.0.70", 6666, "RDR", "Wi-Fi", "Wi-Fi");
            DbFieldsInfo dbFieldsInfo = new DbFieldsInfo() { UNameField = "30", UPassField = "22" };
            IDbClient dbClient = new IrbisDbClient(dbConnectionInfo, dbFieldsInfo);
            IAuthHelper freeRadiusAuthHelper = new FreeRadiusHelper(dbClient);

            String actual = freeRadiusAuthHelper.CheckAccount("10010", "1231");

            Assert.AreEqual(expected, actual);
        }
    }
}
