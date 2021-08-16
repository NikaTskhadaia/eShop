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

        public IEnumerable<OrderDetailsDTO> GetOrderDetails(Guid orderId)
        {
            return _orderDomainService.GetOrderDetails(orderId);
        }
    }
}
