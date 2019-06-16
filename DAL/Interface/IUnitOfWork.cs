using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entitys;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Admin> Admins { get; }
        IRepository<Client> Clients { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Product> Products { get; }
        void SaveChanges();
    }
}
