using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Repositories;
using KindergartenManagementSystem.Models;

namespace KindergartenManagementSystem.Controllers
{
    public class EatScoreController : Controller
    {
        private IEatScoreRepository _repository;

        public IActionResult Index()
        {
            // 登录后能判断是否是教师
            bool isTeacher = HttpContext.User.Claims.ElementAt(1).Value == "teacher";
            if (isTeacher)
            {
                return View();
            }
            else
            {
                // 判断是学生， 有学生id
                int stu_id = 2;
                return Redirect("/SeeEatScore/GetScoreDiagram?stu_id=" + stu_id);
            }
        }

        public EatScoreController(IEatScoreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEatScore()
        {
            return View(new EatScore());
        }

        [HttpPost]
        public IActionResult GetEatScore(EatScore eatScore)
        {
            if (ModelState.IsValid)
            {
                eatScore.Date = DateTime.Now.ToString("yyyy-MM-dd");
                _repository.InsertEatScore(eatScore);
                return Redirect("/EatScore/SetEatScore");
            }
            return View(eatScore);
        }

        public IActionResult SetEatScore(string stu_id, string teacher, int stars_num, string note)
        {
            // 插入数据库
            //_repository.InsertEatScore(
            //    new EatScore
            //{
            //        StuId = int.Parse(stu_id),
            //        Teacher = teacher,
            //        Date = DateTime.Now.ToString("yyyy-MM-dd"),
            //        Score = stars_num,
            //        Note = note
            //    });
            return View();
        }
    }
}