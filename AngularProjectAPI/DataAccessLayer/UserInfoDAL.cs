using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserInfoDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = null;

        public Guid InsertUserInfo(BE.UserInfo objUserInfo)
        {
            try
            {
                Guid newid = Guid.Empty;
                cmd = new SqlCommand("InsertUserInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", objUserInfo.firstname);
                cmd.Parameters.AddWithValue("@lastname", objUserInfo.lastname);
                cmd.Parameters.AddWithValue("@dob", objUserInfo.dob);
                cmd.Parameters.AddWithValue("@age", objUserInfo.age);
                cmd.Parameters.AddWithValue("@location", objUserInfo.location);
                cmd.Parameters.AddWithValue("@uid", objUserInfo.uid);
                cmd.Parameters.Add("@uiid", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@uiid"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                newid = new Guid(cmd.Parameters["@uiid"].Value.ToString());
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
        public bool UpdateUserinfo(BE.UserInfo objUserInfo)
        {
            try
            {
                int result = 0;
                cmd = new SqlCommand("UpdateUserInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@firstname", objUserInfo.firstname);
                cmd.Parameters.AddWithValue("@lastname", objUserInfo.lastname);
                cmd.Parameters.AddWithValue("@dob", objUserInfo.dob);
                cmd.Parameters.AddWithValue("@age", objUserInfo.age);
                cmd.Parameters.AddWithValue("@location", objUserInfo.location);
                cmd.Parameters.AddWithValue("@uiid", objUserInfo.uiid);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public BE.UserInfo GetUserInfoByUId(Guid uid)
        {
            try
            {
                cmd = new SqlCommand("GetUserInfoByUid",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                BE.UserInfo objUserinfo = null;

                if (dt.Rows.Count > 0)
                {

                    objUserinfo = new BE.UserInfo();
                    objUserinfo.uiid = new Guid(dt.Rows[0]["uiid"].ToString());
                    objUserinfo.firstname = dt.Rows[0]["firstname"].ToString();
                    objUserinfo.lastname = dt.Rows[0]["lastname"].ToString();
                    objUserinfo.dob = Convert.ToDateTime(dt.Rows[0]["dob"].ToString());
                    objUserinfo.age = Convert.ToInt16(dt.Rows[0]["age"].ToString());
                    objUserinfo.location = dt.Rows[0]["location"].ToString();
                    objUserinfo.uid = new Guid(dt.Rows[0]["uid"].ToString());

                }
                return objUserinfo;
            }
            catch (Exception)
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
