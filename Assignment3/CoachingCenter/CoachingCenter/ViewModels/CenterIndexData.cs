using CoachingCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CoachingCenter.ViewModels
{
    public class CenterIndexData
    {
        public IEnumerable<Center> Centers { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set;
        }
    }
}