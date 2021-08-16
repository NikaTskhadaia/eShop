using eShop.DataTransferObject;
using eShop.DomainModel.Aggreagates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IProductDomainService
    {
        IEnumerable<ProductDTO> GetAll();
        void SaveProduct(ProductDTO productDTO);
        ProductDTO Get(Guid id);
        void Delete(Guid productId);
    }
}
