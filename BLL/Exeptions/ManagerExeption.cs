using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exeptions
{
    public class ManagerExeption : Exception
    {
        private string message;

        public ManagerExeption(string exception)
        {
            message = exception;
        }

        public ManagerExeption() : base()
        {

        }

        public override string Message => message;
    }
}