using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UserProfile
    {
        public Guid upid { get; set; }
        public string skills { get; set; }
        public float experience { get; set; }
        public string company { get; set; }
        public string certificate { get; set; }
        public string resume { get; set; }
        public Guid uiid { get; set; }

    }
}
