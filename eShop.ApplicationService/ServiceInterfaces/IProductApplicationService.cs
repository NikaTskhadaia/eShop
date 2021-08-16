using eShop.DataTransferObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IProductApplicationService
    {
        IEnumerable<ProductDTO> GetAll();
        void SaveProduct(ProductDTO productDTO);
        string SaveProductImage(IFormFile image);
        ProductDTO Get(Guid id);
        void Delete(Guid productId);
    }
}
