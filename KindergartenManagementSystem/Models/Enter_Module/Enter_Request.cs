using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Models
{
    public class Enter_Request
    {
        int pro_id { get; set; }
        int status { get; set; }
        string starter { get; set; }
        string approver { get; set; }
        int form { get; set; }
    }
}
