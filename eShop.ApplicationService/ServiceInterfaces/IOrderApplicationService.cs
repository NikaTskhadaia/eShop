using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IOrderApplicationService
    {
        IEnumerable<OrderDTO> GetAll();
        IEnumerable<OrderDetailsDTO> GetOrderDetails(Guid orderId);
    }
}
