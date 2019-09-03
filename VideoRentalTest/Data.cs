using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
   public class Data
    {

       public String appsetting = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        public SqlConnection DataConnection()
        {
            sqlConn = new SqlConnection(appsetting);
            return sqlConn;

        }
        public void SqlOpen()
        {
            try
            {
                sqlConn.Open();
            }
            catch (Exception e)
            {

            }


        }
        public void SqlClose()
        {
            sqlConn.Close();
            sqlConn.Dispose();
        }
    }
}
