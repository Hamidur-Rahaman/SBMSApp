using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SBMProjectDAL.common
{
    public class SqlFactory
    {
        private static string _conStr = ConfigurationManager.ConnectionStrings["SBMDbContext"].ToString();
        private static SqlConnection _con = new SqlConnection(_conStr);
        private SqlCommand _cmd = new SqlCommand("", _con);
        public DataTable ExecuteQuery(string sQuery)
        {
            string error = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                _cmd.CommandText = sQuery;
                _con.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter(_cmd);
                myAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _con.Close();
            }
            return dt;
        }

        public String GetSingleValue(string sql)
        {
            var value = (string)null;
            try
            {
                _cmd.CommandText = sql;
                _con.Open();
                value = _cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                value = ex.Message;
            }
            finally
            {
                _con.Close();
            }
            return value;
        }

        public String ExecuteSP(SqlCommand sqlCommand)
        {
            var value = (string)null;
            try
            {
                _con.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery().ToString();
                value = "1";
            }
            catch (Exception ex)
            {
                value = ex.Message;
            }
            finally
            {
                _con.Close();
            }
            return value;
        }
    }
}
