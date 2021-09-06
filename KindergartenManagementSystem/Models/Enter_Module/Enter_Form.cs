using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Models.Enter_Module
{
    public class Enter_Form
    {
        int form_id { get; set; }
        int id { get; set; }
        string name { get; set; }
        DateTime birthday { get; set; }
        bool sex { get; set; }
        string gua_name { get; set; }
        string gua_phone { get; set; }
        string home_addr { get; set; }
        string cla{ get; set; }
        string suggest { get; set; }
    }
}
