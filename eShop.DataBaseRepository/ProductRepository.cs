using eShop.DataBaseRepository.Data;
using eShop.DataBaseRepository.Models;
using eShop.DataTransferObject;
using eShop.DomainModel.Aggreagates;
using eShop.DomainService.RepositoriInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class ProductRepository : IProductRepository
    {
        private void ChangeImagePath(string imagePath, Guid productID)
        {
            using (eShopDBContext context = new())
            {
                var productimages = (from p in context.ProductImages
                               where p.ProductId == productID
                               select p).FirstOrDefault();

                if (productimages is not null)
                {
                    productimages.ImagePath = imagePath;
                    productimages.DateChanged = DateTime.Now;
                    context.SaveChanges();
                }
                else
                {
                    ProductImage productImage = new()
                    {
                        ProductId = productID,
                        ImagePath = imagePath
                    };
                    context.ProductImages.Add(productImage);
                    context.SaveChanges();
                }
            }
        }

        public void SaveProduct(ProductDTO productDTO)
        {
            using (eShopDBContext context = new())
            {
                var product = (from p in context.Products
                                where p.Id == productDTO.ID
                                select p).FirstOrDefault();

                var unitID = context.Units.Where(u => u.Name == productDTO.Unit).Select(u => u.Id).FirstOrDefault();

                if (product is not null)
                {
                    product.Name = productDTO.Name;
                    product.Description = productDTO.Description;
                    product.Price = productDTO.Price;
                    product.Quantity = productDTO.Quantity;
                    product.UnitId = unitID;
                    product.DateChanged = DateTime.Now;

                    context.SaveChanges();
                }
                else
                {
                    Product p = new()
                    {
                        Name = productDTO.Name,
                        Description = productDTO.Description,
                        Price = productDTO.Price,
                        Quantity = productDTO.Quantity,
                        UnitId = unitID
                    };

                    context.Products.Add(p);
                    context.SaveChanges();

                    productDTO.ID = p.Id;
                }
            }


            if (!string.IsNullOrEmpty(productDTO.ImagePath))
            {
                ChangeImagePath(productDTO.ImagePath, productDTO.ID);
            }
        }

        public ProductDTO Get(Guid id)
        {
            using (eShopDBContext context = new())
            {
                var product = (from p in context.Products
                               where p.Id == id
                               join unit in context.Units on p.UnitId equals unit.Id
                               select new ProductDTO {
                                   ID = p.Id,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Price = p.Price,
                                   Unit = unit.Name,
                                   Quantity = p.Quantity
                               }).FirstOrDefault();

                return product;
            }
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            using (eShopDBContext context = new())
            {
                var query = (from p in context.Products
                             where p.DateDeleted == null
                             join unit in context.Units on p.UnitId equals unit.Id
                             join image in  context.ProductImages on p.Id equals image.ProductId into productWithImage
                             from pwi in productWithImage.DefaultIfEmpty()
                             select new ProductDTO { 
                                 ID = p.Id,
                                 ImagePath = pwi.ImagePath ?? null,
                                 Name = p.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                                 Unit = unit.Name,
                                 Quantity = p.Quantity
                             }).Distinct().ToList();

                return query;
            }
        }

        public void Delete(Guid productId)
        {
            using (eShopDBContext context = new())
            {
                var product = (from p in context.Products
                               where p.Id == productId
                               select p).FirstOrDefault();

                if (product is not null)
                {
                    product.DateDeleted = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
    }
}