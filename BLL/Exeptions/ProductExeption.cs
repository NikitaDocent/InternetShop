using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exeptions
{
    public class ProductExeption : Exception
    {
        private string message;

        public ProductExeption(string exception)
        {
            message = exception;
        }

        public ProductExeption() : base()
        {

        }

        public override string Message => message;
    }
}
