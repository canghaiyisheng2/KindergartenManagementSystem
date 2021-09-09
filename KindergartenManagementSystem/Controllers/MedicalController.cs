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
    public class MedicalController : Controller
    {
        IMedicalRepository _medicalRepository;

        public MedicalController(IMedicalRepository medicalRepository)
        {
            _medicalRepository = medicalRepository;
        }

        public IActionResult ShowMedical()
        {
            return View(_medicalRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Medical = _medicalRepository.GetMedicalById(id);
            if (Medical == null)
            {
                return NotFound();
            }
            return View(Medical);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _medicalRepository.RemoveMedical(id);
                return RedirectToAction("ShowMedical");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medical medical)
        {
            if(ModelState.IsValid)
            {
                
                _medicalRepository.AddMedical(medical);

                return RedirectToAction("ShowMedical");
            }
            return View(medical);
        }

        [HttpGet]
        public IActionResult Change()
        {
            return View();
        }

        
    }
}