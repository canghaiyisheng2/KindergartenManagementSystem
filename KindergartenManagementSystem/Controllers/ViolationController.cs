using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Services.ViolationService;
using KindergartenManagementSystem.Models.ViolationModels;
using KindergartenManagementSystem.Services.UserService;
using KindergartenManagementSystem.Models.shared;
using Microsoft.AspNetCore.Authorization;
using KindergartenManagementSystem.Data;

namespace KindergartenManagementSystem.Controllers
{
    [Authorize]
    public class ViolationController : Controller
    {
        private IRecordService _repository;
        private IUserService _service;
        private KindergartenMSContext _context;

        public ViolationController(IRecordService repository, IUserService service, KindergartenMSContext context)
        {
            _repository = repository;
            _service = service;
            _context = context;
        }
        public IActionResult ViolationMainPage()
        {
            ViewBag.auth = User.Claims.ElementAt(1).Value;
            if (User.Claims.ElementAt(1).Value.Equals("student"))
            { 
                ViewBag.value = 0;
                string userName = HttpContext.User.Claims.ElementAt(0).Value;
                User user = _service.GetUserByName(userName);
                if (user == null) return View(null);
                int id = user.banding;
                var temp = _repository.GetRecordsById(id);
                List<Record> re = new List<Record>();
                if (temp == null)
                {
                    return View(re);
                }
                else
                {
                    re.Add(temp);
                    return View(re);
                }
            }
            else if (User.Claims.ElementAt(1).Value.Equals("teacher"))
            {
                ViewBag.value = 1;
                return View(_repository.GetRecords());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult AddRecord()
        {
            return View();
        }

        [HttpPost, ActionName("AddRecord")]
        public IActionResult AddRecordPost(Record record)
        {
            if (ModelState.IsValid)
            {
                if(_context.Records.FirstOrDefault(m => m.childId == record.childId) != null)
                {
                    ViewBag.err = "已记录该学生违纪记录";
                    return View(record);
                }
                _repository.CreateRecord(record);
                return RedirectToAction(nameof(ViolationMainPage));
            }
            return View(record);
        }

        [HttpGet]
        public IActionResult DeleteRecord(int id)
        {
            var record = _repository.GetRecordsById(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost, ActionName("DeleteRecord")]
        public IActionResult DeleteRecordPost(int id)
        {
            _repository.DeleteRecord(id);
            return RedirectToAction(nameof(ViolationMainPage));
        }

        [HttpGet]
        public IActionResult EditRecord(int id)
        {
            Record record = _repository.GetRecordsById(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost, ActionName("EditRecord")]
        public async Task<IActionResult> EditRecordPost(int id)
        {
            var recordToUpdate = _repository.GetRecordsById(id);
            bool isUpdated = await TryUpdateModelAsync<Record>(
                                     recordToUpdate,
                                     "",
                                     c => c.reason,
                                     c => c.score);
            if (isUpdated == true)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(ViolationMainPage));
            }
            return View(recordToUpdate);
        }
    }
}