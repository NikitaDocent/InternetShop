using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exeptions
{
    public class ClientException : Exception
    {
        private string message;

        public ClientException(string exception)
        {
            message = exception;
        }

        public ClientException() : base()
        {

        }

        public override string Message => message;
    }
}
