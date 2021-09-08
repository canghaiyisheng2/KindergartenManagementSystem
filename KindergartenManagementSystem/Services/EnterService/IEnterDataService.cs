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
        List<Enter_Request> GetAll();
        List<Enter_Request> GetApproving();
        List<Enter_Request> GetFinished();
        List<Enter_Request> GetTerminated();
        void AddRequest(Enter_Request enter_Request);
        void ApproveAccept(int id, string suggest);
        void ApproveReject(int id, string suggest);
    }
}
