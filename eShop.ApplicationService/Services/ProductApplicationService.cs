using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Utility;
using eShop.DomainModel.Aggreagates;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eShop.ApplicationService.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductApplicationService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _productDomainService.GetAll();
            return products;
        }

        public string SaveProductImage(IFormFile image)
        {
            using (MemoryStream ms = new())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();

                var filename = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", filename.ToString());

                FileStream stream = new(path, FileMode.Create);
                stream.Close();

                File.WriteAllBytes(path, fileBytes);

                return Path.Combine(@"\images", filename.ToString());
            }
        }

        public void SaveProduct(ProductDTO productDTO)
        {
            _productDomainService.SaveProduct(productDTO);
        }

        public ProductDTO Get(Guid id)
        {
            return _productDomainService.Get(id);
        }

        public void Delete(Guid productId)
        {
            _productDomainService.Delete(productId);
        }
    }
}
