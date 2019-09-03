using System;
using System.Data;
using System.Data.SqlClient;

namespace VideoRental
{
    public class Biz
    {
        Data dataLayer = new Data();

    
        public DataTable getExecutSP_DataTableWithParamter(string SPName, SqlParameter[] SP)
        {
            SqlCommand cmd = new SqlCommand(SPName, dataLayer.DataConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SPName;
            cmd.CommandTimeout = 600;
            foreach (SqlParameter sp in SP)
            {
                cmd.Parameters.Add(sp);
            }



            try
            {
                dataLayer.SqlOpen();
                da.SelectCommand = cmd;
                da.Fill(dt);
                dataLayer.SqlClose();

            }
            catch (Exception e)
            {
                // Response.Write(" <script>alert('"+e.ToString()+"')</script>");

            }
            finally
            {
                cmd.Dispose();
                dataLayer.SqlClose();
            }
            return dt;


        }

        public DataTable getExecutSP_DataTableWithoutParamter(string SPName)
        {
            SqlCommand cmd = new SqlCommand(SPName, dataLayer.DataConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SPName;
            cmd.CommandTimeout = 600;
            try
            {
                dataLayer.SqlOpen();
                da.SelectCommand = cmd;
                da.Fill(dt);
                dataLayer.SqlClose();

            }
            catch { }
            finally
            {
                cmd.Dispose();
                dataLayer.SqlClose();
            }
            return dt;


        }

     
    }
}
