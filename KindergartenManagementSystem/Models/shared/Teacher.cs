using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KindergartenManagementSystem.Models.shared
{
    public class Teacher
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string cla { get; set; } //class
    }
}
