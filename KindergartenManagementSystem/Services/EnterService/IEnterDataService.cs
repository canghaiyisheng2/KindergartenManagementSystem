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
        List<Enter_Request> GetByStarterAndStatus(string starter,int status);
        List<Enter_Request> GetByTeacherAndStatus(string cla, int status);
        void AddRequest(Enter_Request enter_Request);
        void ApproveAccept(int id, string suggest, string approver);
        void ApproveReject(int id, string suggest, string approver);
    }
}
