using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Services;
using KindergartenManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using KindergartenManagementSystem.Models;

namespace KindergartenManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        IEnterDataService _data;
        IAbsenceService _absenceService;

        public HomeController(IEnterDataService data, IAbsenceService absenceService)
        {
            _data = data;
            _absenceService = absenceService;
        }

        
        public IActionResult Index(int? status)
        {
            List<Enter_Request> enter_Requests = null;
            if (status == null) status = 3;

            //获取入托申请流程
            if (User.Claims.ElementAt(1).Value.Equals("student"))
            {
                enter_Requests = _data.GetByStarterAndStatus(User.Claims.First().Value, (int)status);
            }
            else if (User.Claims.ElementAt(1).Value.Equals("teacher"))
            {
                string username = User.Claims.First().Value;
                enter_Requests = _data.GetByTeacherAndStatus(username, (int)status);
            }

            List<process> processes = new List<process>();
            if(enter_Requests != null)
            {
                foreach (Enter_Request item in enter_Requests)
                {
                    processes.Add(new process(item));
                }
            }

            return View(new HomeIndexList(processes));
        }
    }
}
