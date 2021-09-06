using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IOrderDomainService
    {
        IEnumerable<OrderDTO> GetAll();
        IEnumerable<OrderDetailsDTO> GetOrderDetails(Guid orderId);
        Guid SaveOrder(OrderDTO order);
        OrderDTO GetBasket(Guid sessionId);
        void SaveOrderDetails(OrderDetailsDTO orderDetails);
    }
}
