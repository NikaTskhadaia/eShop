using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApplicationService _orderApplicationService;

        public OrderController(IOrderApplicationService orderApplicationService)
        {
            _orderApplicationService = orderApplicationService;
        }
        public IActionResult Index()
        {
            var orders = _orderApplicationService.GetAll();

            return View(orders);
        }

        [HttpGet]
        public IActionResult GetDetails(Guid orderId)
        {
            var orderDetails = _orderApplicationService.GetOrderDetails(orderId);
            return PartialView("_OrderDetails", orderDetails);
        }
    }
}
