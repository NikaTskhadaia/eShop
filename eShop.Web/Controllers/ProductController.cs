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
            Guid orderid;
            Guid userId = Guid.Parse(HttpContext.Session.GetString("SessionID"));

            OrderDTO basket = _orderApplicationService.GetBasket(userId);

            if (basket is null)
            {
                basket = new OrderDTO
                {
                    UserID = userId,
                    DateCreated = DateTime.Now,
                    OrderStatus = OrderStatus.Basket
                };
                
                orderid = _orderApplicationService.SaveOrder(basket);
            }
            else
            {
                orderid = basket.ID;
            }

            var product = _productApplicationService.Get(id);

            var orderDetails = new OrderDetailsDTO 
            {
                OrderID = orderid,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity,
                DateCreated = DateTime.Now
            };

            _orderApplicationService.SaveOrderDetails(orderDetails);

            return View();
        }
    }
}
