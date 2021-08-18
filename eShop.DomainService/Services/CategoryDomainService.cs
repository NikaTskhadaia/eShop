using eShop.DataTransferObject;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly ICategoryRepository _categroyRepository;

        public CategoryDomainService(ICategoryRepository categroyRepository)
        {
            _categroyRepository = categroyRepository;
        }

        public void Delete(int id)
        {
            _categroyRepository.Delete(id);
        }

        public CategoryDTO Get(int id)
        {
            return _categroyRepository.Get(id);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _categroyRepository.GetAll();
        }

        public void SaveCategory(CategoryDTO category)
        {
            _categroyRepository.SaveCategory(category);
        }
    }
}
