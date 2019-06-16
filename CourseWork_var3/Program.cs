using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace CourseWork_var3
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkShop workShop = new WorkShop();
            workShop.RegistryAdmin("Vasia@admin.ua", "12345");
        }
    }
}
