using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface ICategoryApplicationService
    {
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO Get(int id);
        void SaveCategory(CategoryDTO category);
        void Delete(int id);
    }
}
