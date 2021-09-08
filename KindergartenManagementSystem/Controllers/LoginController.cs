using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using KindergartenManagementSystem.Services;

namespace KindergartenManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        ILoginService _checker;

        public LoginController(ILoginService checker)
        {
            _checker = checker;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Login(string username, string password, bool auth)
        {
            if (_checker.CheckLogin(username, password, auth?0:1))
            {
                var claims = new List<Claim>
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.Role, auth?"student":"teacher")
                };
                var identity = new ClaimsIdentity(claims, username);
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrMsg = "用户名或密码错误";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Register(string username, string password, bool auth, string name, string cla)
        {
            if(_checker.Register(username, password, auth ? 0 : 1, name, cla))
            {
                var claims = new List<Claim>
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.Role, auth?"student":"teacher")
                };
                var identity = new ClaimsIdentity(claims, username);
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrMsg = "用户名已存在";
                return View();
            }
        }
        
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}