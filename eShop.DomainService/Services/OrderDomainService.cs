using eShop.DataTransferObject;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDomainService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetails(Guid orderId)
        {
            return _orderRepository.GetOrderDetails(orderId);
        }
    }
}
