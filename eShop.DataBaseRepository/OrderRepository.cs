using eShop.DataBaseRepository.Data;
using eShop.DataBaseRepository.Models;
using eShop.DataTransferObject;
using eShop.DomainService.RepositoriInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<OrderDTO> GetAll()
        {
            using eShopDBContext context = new();
            var orders = (from order in context.Orders
                          join user in context.Users on order.UserId equals user.Id
                          select new OrderDTO
                          {
                              ID = order.Id,
                              UserID = order.UserId,
                              Username = $"{user.FirstName} {user.LastName}",
                              User = user.Email,
                              UserAddress = order.UserAddress.FullAddress,
                              OrderStatus = (DataTransferObject.OrderStatus)order.OrderStatusId,
                              TotalPrice = order.TotalPrice,
                              DateCreated = order.DateCreated,
                              DateChanged = order.DateChanged,
                              DateDeleted = order.DateDeleted

                          }).ToList();

            return orders;
        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetails(Guid orderId)
        {
            using eShopDBContext context = new();
            var orderDetails = (from od in context.OrderDetails
                                where od.OrderId == orderId
                                join p in context.Products on od.ProductId equals p.Id
                                select new OrderDetailsDTO
                                {
                                    ID = od.Id,
                                    OrderID = od.OrderId,
                                    ProductName = p.Name,
                                    Price = od.Price,
                                    Quantity = od.Quantity,
                                    DateCreated = od.DateCreated,
                                    DateChanged = od.DateChanged,
                                    DateDeleted = od.DateDeleted

                                }).ToList();

            return orderDetails;
        }

        public OrderDTO GetBasket(Guid sessionId)
        {
            using eShopDBContext context = new();

            Guid userId = (from u in context.Users
                          where u.SessionId == sessionId
                          select u.Id).FirstOrDefault();

            var basket = (from o in context.Orders
                          where o.UserId == userId && o.OrderStatusId == 0
                          select o).FirstOrDefault();

            return AutomapperExtensions.MapObject<Order, OrderDTO>(basket);
        }
        
        public Guid SaveOrder(OrderDTO order)
        {
            using eShopDBContext context = new();
            Order o = AutomapperExtensions.MapObject<OrderDTO, Order>(order);
            context.Add(o);
            context.SaveChanges();
            return order.ID;
        }

        public void SaveOrderDetails(OrderDetailsDTO orderDetails)
        {
            using eShopDBContext context = new();
            OrderDetail od = AutomapperExtensions.MapObject<OrderDetailsDTO, OrderDetail>(orderDetails);
            context.Add(od);
            context.SaveChanges();
        }
    }
}
