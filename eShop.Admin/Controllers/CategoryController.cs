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

        [HttpGet]
        public string GetCategory(int id)
        {
            var category = _categroyApplicationService.Get(id);
            return JsonSerializer.Serialize(category);
        }

        [HttpPost]
        public IActionResult SaveCategory(CategoryDTO category)
        {
            _categroyApplicationService.SaveCategory(category);

            return Redirect("/Category");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int Id)
        {
            _categroyApplicationService.Delete(Id);

            return Redirect("/Category");
        }
    }
}
