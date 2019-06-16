using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exeptions
{
    public class AdminException : Exception
    {
        private string message;

        public AdminException(string exception)
        {
            message = exception;
        }

        public AdminException() : base()
        {

        }

        public override string Message => message;
    }
}
