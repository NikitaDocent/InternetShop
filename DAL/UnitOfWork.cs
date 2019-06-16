using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Repository;
using Entity.Entitys;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private AccessContext accessContext;

        private AdminRepository adminRepository;
        private ClientRepository clientRepository;
        private ProductRepository productRepository;
        private ManagerRepository managerRepository;
      
        public UnitOfWork(string connectionString)
        {
            accessContext = new AccessContext(connectionString);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        public  IRepository<Admin> Admins {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(accessContext);

                return adminRepository;
            }
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(accessContext);

                return clientRepository;
            }
        }
        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                    managerRepository = new ManagerRepository(accessContext);

                return managerRepository;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(accessContext);

                return productRepository;
            }
        }

        public void SaveChanges()
        {
            accessContext.SaveChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false; // Для определения избыточных вызовов
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    accessContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
