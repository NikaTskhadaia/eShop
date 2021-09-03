using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly IOrderApplicationService _orderApplicationService;

        public ProductController(IProductApplicationService productApplicationService, IOrderApplicationService orderApplicationService)
        {
            _productApplicationService = productApplicationService;
            _orderApplicationService = orderApplicationService;
        }

        public IActionResult Index(Guid id)
        {
            var product = _productApplicationService.Get(id);

            return View(product);
        }

        public IActionResult AddToCart(Guid id, int quantity)
        {
            var order = new OrderDTO
            {
                UserID = Guid.Parse(HttpContext.Session.GetString("SessionID")),
                DateCreated = DateTime.Now,
                OrderStatus = OrderStatus.Basket
            };


            var orderDetails = new OrderDetailsDTO();

            return null;
        }
    }
}
