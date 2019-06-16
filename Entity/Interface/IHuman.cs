using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IHuman
    {
        int Id { get; set; }
        string Email { get; set; }
        string Parol { get; set; }
    }
}
