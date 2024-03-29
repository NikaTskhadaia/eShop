﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class OrderDTO
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string User { get; set; }
        public string Username { get; set; }
        public string UserAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
    }

    public enum OrderStatus : byte
    {
        Basket = 0,
        Unpaid = 1,
        Paid = 2,
        Cancelled = 4
    }
}
