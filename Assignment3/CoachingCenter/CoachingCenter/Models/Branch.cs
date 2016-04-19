using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoachingCenter.Models
{
    public class Branch
    {
        public int id { get; set; }

        public string name { get; set; }

        public string mobile { get; set; }
        public string address { get; set; }

        public string city { get; set; }

        public int centerid { get; set; }

        public virtual Center center { get; set; }
    }
}