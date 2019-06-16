using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        int Cost { get; set; }
        string Type { get; set; }
        int Count { get; set; }
        void AddToAssortiment();
        void AddToAssortiment(int count);
    }
}
