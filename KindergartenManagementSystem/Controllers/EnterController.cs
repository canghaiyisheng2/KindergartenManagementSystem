using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KindergartenManagementSystem.Controllers
{
    [Authorize]
    public class EnterController : Controller
    {
        IEnterDataService _data;

        public EnterController(IEnterDataService data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult EnterForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterDetail(int? id)
        {
            Enter_Request enter_Request = null;
            if(id != null)
                enter_Request = _data.GetRequestById(id);
            ViewBag.auth = User.Claims.ElementAt(1).Value;
            return View(enter_Request);
        }

        [HttpPost]
        public IActionResult EnterForm(Enter_Request enter_Request)
        {
            if (ModelState.IsValid)
            {
                enter_Request.Status = 0;
                enter_Request.Starter = User.Claims.First().Value;
                _data.AddRequest(enter_Request);
                return RedirectToAction("Index", "Home");
            }
            return View(enter_Request);
        }

        [HttpPost]
        public IActionResult Approve(bool result ,string suggest ,int id)
        {
            if (result)
                _data.ApproveAccept(id, suggest);
            else
                _data.ApproveReject(id, suggest);
            return RedirectToRoute(new { action = "EnterDetail", id = id});
        }
    }
}
