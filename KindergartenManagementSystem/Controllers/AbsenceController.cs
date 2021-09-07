using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenManagementSystem.Controllers
{
    public class AbsenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult studentAskForAbsence()
        {
            return View();
        }

        public IActionResult studentListAbsence()
        {
            return View();
        }

        public IActionResult studentDisplayAbsenceInfo()
        {
            return View();
        }

        public IActionResult studentReportedBackFromLeave()
        {
            return View();
        }

        public IActionResult teacherListAbsence()
        {
            return View();
        }

        public IActionResult teacherDisplayAbsenceInfo()
        {
            return View();
        }

        public IActionResult teacherAcceptAbsence()
        {
            return View();
        }

        public IActionResult teacherRejectAbsence()
        {
            return View();
        }
    }
}