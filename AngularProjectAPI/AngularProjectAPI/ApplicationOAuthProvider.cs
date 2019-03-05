using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
//using angularProject.Helper;
//using angularProject.Helper;
//using AngularWebAPIDataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using DA=DataAccessLayer;
using BE = BusinessEntity;
namespace AngularWebAPI
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        DA.UserDal objUserDAL = null;
        BE.User RetriveUser = null;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, PUT, DELETE, POST, OPTIONS" });
            context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type, Accept, Authorization" });
            context.Response.Headers.Add("Access-Control-Max-Age", new[] { "1728000" });

            BE.User objUser = new BE.User();
            objUser.username = context.UserName;
            objUser.password = context.Password;
            objUserDAL = new DA.UserDal();
            RetriveUser = objUserDAL.login(objUser);
            if (string.IsNullOrEmpty(RetriveUser.uid.ToString()))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
           
            //USERMST usrmst = userService.GetUserInfo(context.UserName, context.Password);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("Username", context.UserName));
            //identity.AddClaim(new Claim("FullName", usrmst.User_Name));
            //identity.AddClaim(new Claim("ID", Convert.ToString(usrmst.User_ID)));
            //identity.AddClaim(new Claim("Age", usrmst.User_Age));
            //identity.AddClaim(new Claim("DOB", usrmst.User_DOB));
            //identity.AddClaim(new Claim("Location", usrmst.User_Location));
            //identity.AddClaim(new Claim("Username", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));

            context.Validated(identity);

          
        }
    }
}