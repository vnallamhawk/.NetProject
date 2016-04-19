using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoachingCenter.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string skill { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Center> Centers { get; set; }
    }
}