using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Utility
{
    public class ExceptionList : Exception
    {
        public List<string> Errors { get; private set; }

        public ExceptionList(List<string> errors)
        {
            Errors = errors;
        }
    }
}