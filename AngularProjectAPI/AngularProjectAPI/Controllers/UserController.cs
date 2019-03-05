using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DA=DataAccessLayer;
using BE=BusinessEntity;
using System.Text;
using BusinessEntity;
using System.Security.Claims;

namespace AngularProjectAPI.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class UserController : ApiController
    {
        DA.UserDal objUserDAL = null;
        BE.User RetriveUser = null;
        [HttpPost]
        public IHttpActionResult Login(BE.User objUser)
        {
            objUserDAL= new DA.UserDal();
            RetriveUser = objUserDAL.login(objUser);
            if (!string.IsNullOrEmpty(RetriveUser.uid.ToString()))
            {

                return Ok(new { result = RetriveUser });
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);

        }
        [HttpGet]
        [Authorize]
        [Route("api/GetUserClaims")]
        public User GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            User model = new User()
            {
                username = identityClaims.FindFirst("Username").Value,
                //Age = identityClaims.FindFirst("Age").Value,
                //DOB = identityClaims.FindFirst("DOB").Value,
                //Location = identityClaims.FindFirst("Location").Value,
                //ID = identityClaims.FindFirst("ID").Value
            };
            return model;
        }
    }

    
}
