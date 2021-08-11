using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserApplicationService _userApplicationService;

        public AuthController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginModel userModel)
        {
            var responseCore = _userApplicationService.Login(new LoginDTO() {
                Email = userModel.Email,
                PasswordHash = userModel.PasswordHash            
            });

            if (responseCore.Messages.Count == 0)
            {
                HttpContext.Session.SetString("SessionID", responseCore.SessionID.ToString());
                HttpContext.Session.SetString("UserName", userModel.Email);
                return Redirect("/");
            }

            return View(responseCore.Messages);
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            Guid sessionId = Guid.Parse(HttpContext.Session.GetString("SessionID"));

            _userApplicationService.Logout(sessionId);

            return Redirect("/");
        }
    }
}
