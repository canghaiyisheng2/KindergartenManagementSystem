using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Models
{
    // 请假实体类
    public class Absence
    {
        int id { get; set; }
        int starter { get; set; }
        int approver { get; set; }
        DateTime fromTime { get; set; }
        DateTime toTime { get; set; }
        string location { get; set; }
        string reason { get; set; }
        string rejectReason { get; set; }
        int status { get; set; }
    }
}
