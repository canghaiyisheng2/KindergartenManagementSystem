using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.EnterModels;

namespace KindergartenManagementSystem.Services.EnterService
{
    public class EnterDataService : IEnterDataService
    {
        public List<Enter_Request> enter_Requests { get; set; }

        public void AddRequest(Enter_Request enter_Request)
        {
            throw new NotImplementedException();
        }

        public Enter_Request GetRequestById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
