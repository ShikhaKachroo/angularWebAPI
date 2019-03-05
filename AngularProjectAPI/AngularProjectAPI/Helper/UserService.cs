using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using angularProject.Models;
using AngularProjectDataAccessLayer;

namespace angularProject.Helper
{
    public class UserService
    {
        AngularDataAccessLayer objAngularDataAccessLayer = new AngularDataAccessLayer();
        public bool Login(string username, string password)
        {
            return objAngularDataAccessLayer.VerifyLogin(username, password).Rows.Count>0?true:false;
        }
        //public Users GetUserInfo(string username, string password)
        //{
        //    using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
        //    {
        //        return entities.USERMSTs.Where(user =>
        //               user.User_Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        //                                  && user.User_Password == password).SingleOrDefault();
        //    }
        //}
    }
}