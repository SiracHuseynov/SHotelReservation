using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Exceptions
{
    public class DuplicatePositionException : Exception
    {
        public DuplicatePositionException(string? message) : base(message)
        {

        }
    }
}
