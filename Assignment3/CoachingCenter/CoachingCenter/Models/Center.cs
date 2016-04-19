using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoachingCenter.Models
{
    public class Center
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string email { get; set; }

        public string mobile { get; set; }

       
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}