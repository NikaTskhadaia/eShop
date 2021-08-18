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
    public class CategoryRepository : ICategoryRepository
    {
        public void Delete(int id)
        {
            using (eShopDBContext context = new())
            {
                var category = (from c in context.Categories
                                where c.Id == id
                                select c).FirstOrDefault();

                if (category is not null)
                {
                    category.DateDeleted = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        public CategoryDTO Get(int id)
        {
            using (eShopDBContext context = new())
            {
                var category = (from c in context.Categories
                               where c.Id == id
                               select new CategoryDTO()
                               {
                                   ID = c.Id,
                                   Name = c.Name
                               }).FirstOrDefault();

                return category;
            }

        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            using (eShopDBContext context = new())
            {
                var categories = (from category in context.Categories
                                  where category.DateDeleted == null
                                  select new CategoryDTO
                                  {
                                      ID = category.Id,
                                      Name = category.Name
                                  }).ToList();

                return categories;
            }
        }

        public void SaveCategory(CategoryDTO categoryDTO)
        {
            using (eShopDBContext context = new())
            {
                if (categoryDTO.ID == 0)
                {
                    Category c = new() { Name = categoryDTO.Name, DateCreated = DateTime.Now };
                    context.Add(c);
                    context.SaveChanges();
                    return;
                }

                var category = (from c in context.Categories
                               where c.Id == categoryDTO.ID
                               select c).FirstOrDefault();

                if (category is not null)
                {
                    category.Name = categoryDTO.Name;
                    category.DateChanged = DateTime.Now;
                    context.SaveChanges();
                }

            }
        }
    }
}
