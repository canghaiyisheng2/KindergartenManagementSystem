using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.EnterModels;

namespace KindergartenManagementSystem.Services
{
    public interface IEnterDataService
    {
        List<Enter_Request> enter_Requests { get; set; }
        Enter_Request GetRequestById(int? id);
        void AddRequest(Enter_Request enter_Request);
    }
}
