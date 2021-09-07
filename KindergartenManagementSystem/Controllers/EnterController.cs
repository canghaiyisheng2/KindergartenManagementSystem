using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KindergartenManagementSystem.Controllers
{
    public class EnterController : Controller
    {
        IEnterDataService _data;

        [HttpGet]
        public IActionResult EnterForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterForm(Enter_Request enter_Request)
        {
            if (ModelState.IsValid)
            {
                //_data.AddRequest(enter_Request);
                return RedirectToAction("Index", "Home");
            }
            return View(enter_Request);
        }

        [HttpPost]
        public IActionResult Approve()
        {
            return View();
        }
    }
}
