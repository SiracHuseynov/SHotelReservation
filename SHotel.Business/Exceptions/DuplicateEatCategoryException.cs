using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Exceptions
{
    public class DuplicateEatCategoryException : Exception
    {
        public DuplicateEatCategoryException(string? message) : base(message)
        {
        }
    }
}
