using eShop.ApplicationService.ServiceInterfaces;
using eShop.Web.Attributes;
using eShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        public HomeController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        [Route("/")]
        [Authorize]
        public IActionResult Index()
        {
            var products = _productApplicationService.GetAll().Take(8);

            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }

       
    }
}
