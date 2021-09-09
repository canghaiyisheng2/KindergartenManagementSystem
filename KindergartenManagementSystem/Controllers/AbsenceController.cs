using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Models;
using KindergartenManagementSystem.Models.shared;
using KindergartenManagementSystem.Services;

namespace KindergartenManagementSystem.Controllers
{
    public class AbsenceController : Controller
    {
        IAbsenceService _absenceService;

        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }

        [HttpGet]
        public IActionResult studentAskForAbsence()
        {
            return View();
        }

        [HttpPost]
        public IActionResult studentAskForAbsence(Absence absence)
        {
            if (ModelState.IsValid)
            {
                if (_absenceService.add(absence))
                {
                    ViewBag.Status = "申请成功，等待审核";
                }
                else
                {
                    ViewBag.Status = "申请失败，请检查输入是否合法";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult studentListAbsence()
        {
            ViewBag.list = _absenceService.studentListAbsence("tom");
            return View();
        }

        [HttpGet]
        public IActionResult studentDisplayAbsenceInfo(int absenceID)
        {
            Absence absence = _absenceService.query(absenceID);
            return View(absence);
        }

        public IActionResult studentReportedBackFromLeave(int absenceID)
        {
            if (_absenceService.studentReportedBackFromLeave(absenceID))
            {
                ViewBag.message = "销假成功";
            }
            else
            {
                ViewBag.message = "该请假已经是“结束”状态，不能重复销假";
            }
            return View();
        }

        public IActionResult teacherListAbsence()
        {
            ViewBag.list = _absenceService.teacherListAbsence("jim");
            return View();
        }

        public IActionResult teacherDisplayAbsenceInfo(int absenceID)
        {
            Absence absence = _absenceService.query(absenceID);
            return View(absence);
        }

        [HttpGet]
        public IActionResult teacherAcceptAbsence(int absenceID)
        {
            if (_absenceService.teacherAcceptAbsence(absenceID))
            {
                ViewBag.message = "同意成功";
            } else
            {
                ViewBag.message = "同意失败，该请求不处于“待审核”阶段";
            }
            return View();
        }

        [HttpGet]
        public IActionResult teacherRejectAbsence(int absenceID, string rejectMessage)
        {
            if (_absenceService.teacherRejectAbsence(absenceID, rejectMessage))
            {
                ViewBag.message = "拒绝成功";
            }
            else
            {
                ViewBag.message = "拒绝失败，该请求不处于“待审核”阶段";
            }
            return View();
        }
    }
}