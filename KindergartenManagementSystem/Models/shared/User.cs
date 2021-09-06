using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Models.shared
{
    public class User
    {
        string user_name { get; set; }
        string password { get; set; }
        int auth { get; set; }
        int banding { get; set; }
    }
}
