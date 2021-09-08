using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KindergartenManagementSystem.Models.EnterModels;

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

        public Child() { }

        public Child(Enter_Request enter_Request)
        {
            this.id = enter_Request.Child_Id;
            this.name = enter_Request.Name;
            this.birth = enter_Request.Birthday;
            this.sex = enter_Request.Sex;
            this.cla = enter_Request.Cla;
            this.gua_name = enter_Request.Gua_name;
            this.gua_phone = enter_Request.Gua_phone;
            this.home_addr = enter_Request.Home_addr;
        }
    }
}
