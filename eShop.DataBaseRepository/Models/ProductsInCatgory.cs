﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.Models
{
    public partial class ProductsInCatgory
    {
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}