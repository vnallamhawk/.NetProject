using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoachingCenter.Models
{
    public class Student
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }

        public int teacherid { get; set; }

        public virtual Teacher teacher { get; set; }
    }
}