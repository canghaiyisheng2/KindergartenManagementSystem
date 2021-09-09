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
    public class TeacherAbsenceFilter : ActionFilterAttribute
    {
        IAbsenceService _absenceService;

        public TeacherAbsenceFilter(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int absenceID = int.Parse(filterContext.ActionArguments["absenceID"].ToString());
            string username = filterContext.HttpContext.User.Claims.First().Value;
            if (!_absenceService.hasAuthorityToReview(absenceID, username))
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index");
                filterContext.Result = new EmptyResult();
            }
        }
    }
}
