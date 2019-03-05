using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = BusinessEntity;

namespace BusinessLogic
{
    public class UserLogic
    {
        BusinessLogic.UserLogic objUserLogic = null;
        public BE.User Login(BE.User objUser)
        {
            try
            {
                objUserLogic = new UserLogic();
                BE.User rtvUser = null;
                rtvUser = objUserLogic.Login(objUser);
                return rtvUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
