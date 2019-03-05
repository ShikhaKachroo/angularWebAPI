using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = BusinessEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{


    public class UserDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = null;

        public BE.User login(BE.User objBEUser)
        {
            try
            {
                BusinessEntity.User rtvBEUser = null;
                cmd = new SqlCommand("VerifyLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", objBEUser.username);
                cmd.Parameters.AddWithValue("@password", objBEUser.password);
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    rtvBEUser = new BusinessEntity.User();
                    rtvBEUser.uid = new Guid(dt.Rows[0]["uid"].ToString());
                    rtvBEUser.username = dt.Rows[0]["username"].ToString();

                }
                return rtvBEUser;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public Guid InsertLogin(BE.User objUser)
        {
            try
            {
                Guid newid = Guid.Empty;
                cmd = new SqlCommand("InsertUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", objUser.username);
                cmd.Parameters.AddWithValue("@password", objUser.password);
                cmd.Parameters.Add("@uid", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@uid"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                newid = new Guid(cmd.Parameters["@uid"].Value.ToString());
                return newid;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        
    }
}
