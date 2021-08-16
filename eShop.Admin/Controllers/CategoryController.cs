using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApplicationService _categroyApplicationService;

        public CategoryController(ICategoryApplicationService categroyApplicationService)
        {
            _categroyApplicationService = categroyApplicationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories =  _categroyApplicationService.GetAll();
            return View(categories);
        }
    }
}
