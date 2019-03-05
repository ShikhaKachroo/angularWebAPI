using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DA = DataAccessLayer;
using BE = BusinessEntity;
using System.Text;

namespace AngularProjectAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCorsAttribute("*", "*", "*")]
    public class UserInfoController : ApiController
    {
        DA.UserDal objUserDAL = null;
        DA.UserInfoDAL objUserInfoDAL = null;
        bool qresult = false;
        BE.UserInfo retUserInfo = null;
        Guid registeruserinfo = Guid.Empty;
        Guid registeruserid = Guid.Empty;
        bool ressult = false;
        [HttpPost]
        public IHttpActionResult Register(BE.User objUser)
        {
            objUserDAL = new DA.UserDal();
            registeruserid = objUserDAL.InsertLogin(objUser);
            if (registeruserid != Guid.Empty)
            {
                objUserInfoDAL = new DA.UserInfoDAL();
                objUser.userinfo.uid = registeruserid;
                objUserInfoDAL.InsertUserInfo(objUser.userinfo);

                return Ok(new { result = objUser });
            }
            else
            {
                return BadRequest("Error occure while register");
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        [HttpPost]
        public IHttpActionResult GetUserInfoByUID(string uid)
        {
            objUserInfoDAL = new DA.UserInfoDAL();
            retUserInfo = objUserInfoDAL.GetUserInfoByUId(Guid.Parse(uid.Replace("\"","")));
            if (retUserInfo != null)
            {
                return Ok(new { result = retUserInfo });
            }
            else
            {
                return BadRequest("error occure while geting userinfo");
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateUserInfo(BE.UserInfo objUserInfo)
        {
            objUserInfoDAL = new DA.UserInfoDAL();
            qresult = objUserInfoDAL.UpdateUserinfo(objUserInfo);
            if (qresult)
                return Ok("updated user info");
            else
                return BadRequest("error occure while updating");

        }
    }


}
