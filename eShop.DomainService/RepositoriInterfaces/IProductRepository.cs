﻿using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO Get(Guid id);
        void SaveProduct(ProductDTO productDTO);
        void Delete(Guid productId);
    }
}
