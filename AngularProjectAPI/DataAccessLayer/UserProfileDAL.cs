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
    public class UserProfileDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = null;

        public Guid InsertUserProfile(BE.UserProfile objUserProfile)
        {
            try
            {
                Guid newid = Guid.Empty;
                cmd = new SqlCommand("InsertUserProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skills", objUserProfile.skills);
                cmd.Parameters.AddWithValue("@experience",objUserProfile.experience);
                cmd.Parameters.AddWithValue("@company", objUserProfile.company);
                cmd.Parameters.AddWithValue("@certificate",objUserProfile.certificate);
                cmd.Parameters.AddWithValue("@resume", objUserProfile.resume);
                cmd.Parameters.AddWithValue("@uiid", objUserProfile.uiid);
                cmd.Parameters.Add("@upid", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@upid"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                newid = new Guid(cmd.Parameters["@upid"].Value.ToString());
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
        public bool UpdateUserProfile(BE.UserProfile objUserProfile)
        {
            try
            {
                int result = 0;
                cmd = new SqlCommand("UpdateUserProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skills", objUserProfile.skills);
                cmd.Parameters.AddWithValue("@experience", objUserProfile.experience);
                cmd.Parameters.AddWithValue("@company", objUserProfile.company);
                cmd.Parameters.AddWithValue("@certificate", objUserProfile.certificate);
                cmd.Parameters.AddWithValue("@resume", objUserProfile.resume);
                cmd.Parameters.AddWithValue("@upid", objUserProfile.upid);
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
        public BE.UserProfile GetUserProfileByUIID(Guid uiid)
        {
            try
            {
                cmd = new SqlCommand("GetUserProfileByUIID",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uiid", uiid);
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                BE.UserProfile objUserProfile = null;

                if (dt.Rows.Count > 0)
                {

                    objUserProfile = new BE.UserProfile();
                    objUserProfile.upid = new Guid(dt.Rows[0]["upid"].ToString());
                    objUserProfile.skills = dt.Rows[0]["skills"].ToString();
                    objUserProfile.experience =(float) Convert.ToDouble(  dt.Rows[0]["experience"].ToString());
                    objUserProfile.company = dt.Rows[0]["company"].ToString();
                    objUserProfile.certificate = dt.Rows[0]["certificate"].ToString();
                    objUserProfile.resume = dt.Rows[0]["resume"].ToString();
                    objUserProfile.uiid = new Guid(dt.Rows[0]["uiid"].ToString());

                }
                return objUserProfile;
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
