using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userApplicationService.GetAll();
            return View(users);
        }

        [HttpGet]
        public string GetUser(Guid id)
        {
            var user = _userApplicationService.Get(id);
            return JsonSerializer.Serialize(user);
        }

        [HttpGet]
        public IActionResult DeleteUser(Guid Id)
        {
            _userApplicationService.Delete(Id);

            return Redirect("/User");
        }

        [HttpPost]
        public IActionResult SaveUser(UserDTO user)
        {
            _userApplicationService.SaveUser(user);

            return Redirect("/User");
        }
    }
}
