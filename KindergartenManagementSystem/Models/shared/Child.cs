using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindergartenManagementSystem.Models.shared
{
    public class Child
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birth { get; set; }
        public bool sex { get; set; }
        public string cla { get; set; } //class
        public string gua_name { get; set; }
        public string gua_phone { get; set; }
        public string home_addr { get; set; }
    }
}
