using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class UserAuthResponseDTO : ExceptionDTO
    {
        public Guid? SessionID { get; set; }
    }
}
