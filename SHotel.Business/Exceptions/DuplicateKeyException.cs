using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Exceptions
{
    public class DuplicateKeyException : Exception
    {
        public DuplicateKeyException(string? message) : base(message)
        {

        }
    }
}
