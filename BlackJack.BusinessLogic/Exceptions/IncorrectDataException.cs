using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Exceptions
{
    public class IncorrectDataException : Exception
    {
        public IncorrectDataException() : base()
        {

        }
        public IncorrectDataException(string message) : base(message)
        {

        }
        public IncorrectDataException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
