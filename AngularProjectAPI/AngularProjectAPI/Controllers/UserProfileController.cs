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
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [EnableCorsAttribute("*", "*", "*")]
    public class UserProfileController : ApiController
    {
        BE.UserProfile objUserProfile = null;
        DA.UserProfileDAL objUserProfileDAL;
        Guid ReturnUpid = Guid.Empty;
        bool qResult = false;
        [HttpPost]
        public IHttpActionResult InsertUserProfile(BE.UserProfile objUserProfile)
        {
            objUserProfileDAL = new DA.UserProfileDAL();
            ReturnUpid=objUserProfileDAL.InsertUserProfile(objUserProfile);
            if (ReturnUpid != Guid.Empty)
                return Ok("profile insterted");
            else
                return BadRequest("Error Occure While instering profile");


        }
        [HttpPost]
        public IHttpActionResult UpdateUserProfile(BE.UserProfile objUserProfile)
        {
            objUserProfileDAL = new DA.UserProfileDAL();
            qResult = objUserProfileDAL.UpdateUserProfile(objUserProfile);
            if (qResult)
                return Ok("profile updated");
            else
                return BadRequest("error ocuure while updating");
        }
        [HttpPost]
        public IHttpActionResult GetUserProfile(string uiid)
        {
            objUserProfileDAL = new DA.UserProfileDAL();
            objUserProfile = objUserProfileDAL.GetUserProfileByUIID(Guid.Parse(uiid.Replace("\"","")));
            if (objUserProfile != null)
                return Ok(new { result = objUserProfile });
            else
                return BadRequest("error");
        }
    }
}
