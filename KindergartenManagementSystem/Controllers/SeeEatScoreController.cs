using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace KindergartenManagementSystem.Controllers
{
    [Authorize]
    public class SeeEatScoreController : Controller
    {
        private IEatScoreRepository _repository;

        public SeeEatScoreController(IEatScoreRepository repository)
        {
            _repository = repository;
        }

        public IActionResult GetStudentList()
        {
            return View(_repository.GetAll());
        }

        public IActionResult GetScoreDiagram(int stu_id)
        {
            return View(_repository.GetScoreByStuId(stu_id));
        }
        public IActionResult GetScoreDetail(int stu_id, string date)
        {
            return View(_repository.GetScoreDetails(stu_id, date));
        }
    }
}