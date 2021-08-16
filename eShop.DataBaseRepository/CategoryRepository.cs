using eShop.DataBaseRepository.Data;
using eShop.DataTransferObject;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<CategoryDTO> GetAll()
        {
            using (eShopDBContext context = new())
            {
                var categories = (from category in context.Categories
                                  select new CategoryDTO
                                  {
                                      ID = category.Id,
                                      Name = category.Name
                                  }).ToList();

                return categories;
            }
        }
    }
}
