using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.EnterModels;

namespace KindergartenManagementSystem.ViewModels
{
    public class process
    {
        public int pro_id { get; set; }
        public string starter { get; set; }
        public string approver { get; set; }
        public int status { get; set; }
        public int type { get; set; }

        public process(Enter_Request enter_Request)
        {
            this.pro_id = enter_Request.Pro_id;
            this.starter = enter_Request.Starter;
            this.approver = enter_Request.Approver;
            this.status = enter_Request.Status;
            this.type = 0;
        }
    }
}
