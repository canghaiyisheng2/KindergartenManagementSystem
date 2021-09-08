using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Services;
using KindergartenManagementSystem.ViewModels;

namespace KindergartenManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        IEnterDataService _data;

        public HomeController(IEnterDataService data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            List<Enter_Request> enter_Requests = _data.GetAll();
            List<process> processes = new List<process>();
            foreach(Enter_Request item in enter_Requests)
            {
                processes.Add(new process(item));
            }
            return View(new HomeIndexList(processes));
        }
    }
}
