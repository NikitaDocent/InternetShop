using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entity.Entitys;

namespace DAL
{
    public class AccessContext : DbContext
    {
        public AccessContext(string connectString) : base(connectString)
        {
            Database.SetInitializer<AccessContext>(new DropCreateDatabaseIfModelChanges<AccessContext>());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
