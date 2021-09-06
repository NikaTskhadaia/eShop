using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly IOrderDomainService _orderDomainService;

        public OrderApplicationService(IOrderDomainService orderDomainService)
        {
            _orderDomainService = orderDomainService;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _orderDomainService.GetAll();
        }

        public OrderDTO GetBasket(Guid sessionId)
        {
            return _orderDomainService.GetBasket(sessionId);
        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetails(Guid orderId)
        {
            return _orderDomainService.GetOrderDetails(orderId);
        }

        public Guid SaveOrder(OrderDTO order)
        {
            return  _orderDomainService.SaveOrder(order);
        }

        public void SaveOrderDetails(OrderDetailsDTO orderDetails)
        {
            _orderDomainService.SaveOrderDetails(orderDetails);
        }
    }
}
