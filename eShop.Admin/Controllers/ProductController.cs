using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainService.RepositoriInterfaces;
using eShop.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productApplicationService.GetAll();

            return View(products);
        }

        [HttpGet]
        public string GetProduct(string id)
        {
            Guid productId = Guid.Parse(id);
            var product = _productApplicationService.Get(productId);
            return JsonSerializer.Serialize(product);
        }

        [HttpPost]
        public IActionResult SaveProduct(ProductInputModel productInputModel)
        {
            var product = AutomapperExtensions.MapObject<ProductInputModel, ProductDTO>(productInputModel);

            if (productInputModel.Image is not null)
            {
                product.ImagePath = _productApplicationService.SaveProductImage(productInputModel.Image);
            }

            _productApplicationService.SaveProduct(product);

            return Redirect("/Product");
        }

        [HttpGet]
        public IActionResult DeleteProduct(Guid productId)
        {
            _productApplicationService.Delete(productId);

            return Redirect("/Product");
        }
    }
}
