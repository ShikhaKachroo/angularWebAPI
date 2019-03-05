using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UserInfo
    {
        public Guid uiid { get; set; }
        public DateTime dob { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string location { get; set; }
        public Guid uid { get; set; }
    }
}
