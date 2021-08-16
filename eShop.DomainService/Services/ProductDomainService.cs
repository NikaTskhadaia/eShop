using eShop.DataTransferObject;
using eShop.DomainModel.Aggreagates;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void SaveProduct(ProductDTO productDTO)
        {
            _productRepository.SaveProduct(productDTO);
        }

        public ProductDTO Get(Guid id)
        {
            return _productRepository.Get(id);
        }

        public void Delete(Guid productId)
        {
            _productRepository.Delete(productId);
        }
    }
}
