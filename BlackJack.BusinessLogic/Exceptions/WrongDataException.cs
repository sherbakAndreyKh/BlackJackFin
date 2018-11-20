using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Exceptions
{
    public class WrongDataException : Exception
    {
        public WrongDataException() : base()
        {

        }
        public WrongDataException(string message) : base(message)
        {

        }
        public WrongDataException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
