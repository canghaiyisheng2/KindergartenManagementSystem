using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Models;
using KindergartenManagementSystem.Models.shared;
using KindergartenManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using KindergartenManagementSystem.Filter.AbsenceFilter;

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
        [Authorize(Roles = "student")]
        public IActionResult studentAskForAbsence()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "student")]
        public IActionResult studentAskForAbsence(Absence absence)
        {
            if (ModelState.IsValid)
            {
                absence.starter = User.Claims.First().Value;
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
        [Authorize(Roles = "student")]
        public IActionResult studentListAbsence()
        {
            ViewBag.list = _absenceService.studentListAbsence(User.Claims.First().Value);
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "student")]
        [ServiceFilter(typeof(StudentAbsenceFilter))]
        public IActionResult studentDisplayAbsenceInfo(int absenceID)
        {
            Absence absence = _absenceService.query(absenceID);
            return View(absence);
        }

        [Authorize(Roles = "student")]
        [ServiceFilter(typeof(StudentAbsenceFilter))]
        public IActionResult studentReportedBackFromLeave(int absenceID)
        {
            Absence absence = _absenceService.query(absenceID);

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

        [Authorize(Roles = "teacher")]
        public IActionResult teacherListAbsence()
        {
            string username = User.Claims.First().Value;
            ViewBag.list = _absenceService.teacherListAbsence(username);
            return View();
        }

        [Authorize(Roles = "teacher")]
        [ServiceFilter(typeof(TeacherAbsenceFilter))]
        public IActionResult teacherDisplayAbsenceInfo(int absenceID)
        {
            Absence absence = _absenceService.query(absenceID);
            return View(absence);
        }

        [HttpGet]
        [Authorize(Roles = "teacher")]
        [ServiceFilter(typeof(TeacherAbsenceFilter))]
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
        [Authorize(Roles = "teacher")]
        [ServiceFilter(typeof(TeacherAbsenceFilter))]
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