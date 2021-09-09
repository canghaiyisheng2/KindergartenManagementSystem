using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using KindergartenManagementSystem.Models;
using KindergartenManagementSystem.Services;

namespace KindergartenManagementSystem.Filter.AbsenceFilter
{
    public class StudentAbsenceFilter : ActionFilterAttribute
    {
        IAbsenceService _absenceService;

        public StudentAbsenceFilter(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int absenceID = int.Parse(filterContext.ActionArguments["absenceID"].ToString());
            Absence absence = _absenceService.query(absenceID);
            if (filterContext.HttpContext.User.Claims.First().Value.CompareTo(absence.starter) != 0)
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index");
                filterContext.Result = new EmptyResult();
            }
        }
    }
}
