using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class User
    {
        public Guid uid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public UserInfo userinfo { get; set; }
    }
}
