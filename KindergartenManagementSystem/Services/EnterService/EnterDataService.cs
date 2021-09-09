using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Models.shared;
using KindergartenManagementSystem.Data;

namespace KindergartenManagementSystem.Services.EnterService
{
    public class EnterDataService : IEnterDataService
    {
        KindergartenMSContext _context;

        public EnterDataService(KindergartenMSContext context)
        {
            _context = context;
        }

        public List<Enter_Request> enter_Requests { get; set; }

        public void AddRequest(Enter_Request enter_Request)
        {
            _context.enter_Requests.Add(enter_Request);
            _context.SaveChanges();
        }

        public List<Enter_Request> GetAll()
        {
            return _context.enter_Requests.ToList();
        }

        public List<Enter_Request> GetByStarterAndStatus(string starter, int status)
        {
            List<Enter_Request> res = new List<Enter_Request>();
            IQueryable<Enter_Request> query;
            if (status == 3)
            {
                query = from b in _context.enter_Requests
                        where b.Starter == starter
                        select b;
            }
            else
            {
                query = from b in _context.enter_Requests
                        where b.Starter == starter && b.Status == status
                        select b;
            }

            foreach (Enter_Request item in query)
            {
                res.Add(item);
            }
            return res;
        }

        public List<Enter_Request> GetByTeacherAndStatus(string teacher_username, int status)
        {
            List<Enter_Request> res = new List<Enter_Request>();
            User user = _context.Users.FirstOrDefault(b => b.user_name == teacher_username);
            if (user == null) return null;
            Teacher teacher = _context.Teachers.FirstOrDefault(m => m.id == user.banding);
            if (teacher == null) return null;
            string cla = teacher.cla;

            //查询老师所属班级的相关请求
            IQueryable<Enter_Request> query;
            if (status == 3)
            {
                query = from b in _context.enter_Requests
                        where b.Cla == cla && b.Starter != teacher_username
                        select b;
            }
            else
            {
                query = from b in _context.enter_Requests
                        where b.Cla == cla && b.Status == status && b.Starter != teacher_username
                        select b;
            }

            foreach (Enter_Request item in query)
            {
                res.Add(item);
            }

            //查询教师作为发起者的请求
            List<Enter_Request> requestsWithStarter = GetByStarterAndStatus(teacher_username, status);
            foreach (Enter_Request item in requestsWithStarter)
            {
                res.Add(item);
            }

            return res;
        }

        public Enter_Request GetRequestById(int? id)
        {
            if (id == null) return null;
            return _context.enter_Requests.FirstOrDefault(m => m.Pro_id == id);
        }

        public void ApproveAccept(int id, string suggest, string approver)
        {
            Enter_Request enter_request = GetRequestById(id);
            _context.Children.Add(new Child(enter_request));
            _context.SaveChanges();

            enter_request.Status = 1;
            enter_request.Suggest = suggest;

            int child_id = _context.Children.LastOrDefault(m => m.name == enter_request.Name).id;
            enter_request.Child_Id = child_id;
            User gua_user = _context.Users.FirstOrDefault(m => m.user_name == enter_request.Starter);
            gua_user.banding = child_id;
            _context.SaveChanges();
        }

        public void ApproveReject(int id, string suggest, string approver)
        {
            var enter_request = GetRequestById(id);
            enter_request.Status = 2;
            enter_request.Suggest = suggest;
            enter_request.Approver = approver;
            _context.SaveChanges();
        }
    }
}
