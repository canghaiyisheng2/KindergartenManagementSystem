using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Models.shared
{
    public class Child
    {
        int id { get; set; }
        string name { get; set; }
        DateTime birth { get; set; }
        bool sex { get; set; }
        string cla { get; set; } //class
        string gua_name{ get; set; }
        string gua_phone { get; set; }
        string home_addr { get; set; }
    }
}
