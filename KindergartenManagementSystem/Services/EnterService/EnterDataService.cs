//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using KindergartenManagementSystem.Models.EnterModels;
//using KindergartenManagementSystem.Models.shared;
//using KindergartenManagementSystem.Data;

//namespace KindergartenManagementSystem.Services.EnterService
//{
//    public class EnterDataService : IEnterDataService
//    {
//        KindergartenMSContext _context;

//        public EnterDataService(KindergartenMSContext context)
//        {
//            _context = context;
//        }

//        public List<Enter_Request> enter_Requests { get; set; }

//        public void AddRequest(Enter_Request enter_Request)
//        {
//            _context.enter_Requests.Add(enter_Request);
//            _context.SaveChanges();
//        }

//        public List<Enter_Request> GetAll()
//        {
//            return _context.enter_Requests.ToList();
//        }

//        List<Enter_Request> GetFinished()
//        {

//        }

//        List<Enter_Request> GetTerminated()
//        {

//        }

//        public Enter_Request GetRequestById(int? id)
//        {
//            if (id == null) return null;
//            return _context.enter_Requests.FirstOrDefault(m => m.Pro_id == id);
//        }

//        public void ApproveAccept(int id, string suggest)
//        {
//            Enter_Request enter_request = GetRequestById(id);
//            _context.Children.Add(new Child(enter_request));
//            Console.WriteLine("Child" + enter_request.ToString());
//            enter_request.Status = 1;
//            enter_request.Suggest = suggest;
//            _context.SaveChanges();
//        }

//        public void ApproveReject(int id, string suggest)
//        {
//            var enter_request = GetRequestById(id);
//            enter_request.Status = 2;
//            enter_request.Suggest = suggest;
//            _context.SaveChanges();
//        }
//    }
//}
