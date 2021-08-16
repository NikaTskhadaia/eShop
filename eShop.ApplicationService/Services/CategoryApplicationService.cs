using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly ICategoryDomainService _categroyDomainService;

        public CategoryApplicationService(ICategoryDomainService categroyDomainService)
        {
            _categroyDomainService = categroyDomainService;
        }
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _categroyDomainService.GetAll();
        }
    }
}
