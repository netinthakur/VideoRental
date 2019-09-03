using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRental;

namespace VideoRentalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_LoginWithCorrectCredentails()
        {
            Biz bl = new Biz();
            var loginID = "admin";
            var password = "Admin@123";

            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@userid", loginID);

            sp[1] = new SqlParameter("@pwd", password);
            dt = bl.getExecutSP_DataTableWithParamter("userLogin", sp);
            if (dt != null && dt.Rows.Count > 0)
                Assert.IsTrue(true);
            else
                Assert.IsFalse(false);
        }

        [TestMethod]
        public void Test_LoginWithIncorrectCorrectCredentails()
        {
            Biz bl = new Biz();
            var loginID = "admin";
            var password = "Admin@12344";

            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@userid", loginID);

            sp[1] = new SqlParameter("@pwd", password);
            dt = bl.getExecutSP_DataTableWithParamter("userLogin", sp);
            if (dt != null && dt.Rows.Count > 0)
                Assert.IsTrue(true);
            else
                Assert.IsFalse(false);
        }

        [TestMethod]
        public void Test_GetConnStringFromAppConfig()
        {
            Data da = new Data();
            string actualString = da.appsetting;
            string expectedString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
