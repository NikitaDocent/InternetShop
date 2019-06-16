using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using Entity.Entitys;
using System.Data.Entity;

namespace DAL.Repository
{
    public class AdminRepository : IRepository<Admin>
    {
        private AccessContext accessContext;

        public AdminRepository(AccessContext p_accessContext)
        {
            accessContext = p_accessContext;
        }

        public IEnumerable<Admin> Find(Func<Admin, bool> predicate)
        {
            return accessContext.Admins.Where(predicate).ToList();
        }

        public Admin Get(int id)
        {
            return accessContext.Admins.Find(id);
        }

        public IEnumerable<Admin> GetAll()
        {
            return accessContext.Admins.Local.ToBindingList();
        }

        public void Insert(Admin obj)
        {
            accessContext.Admins.Add(obj);
            accessContext.Entry(obj).State = EntityState.Added;
        }
        public void Update(Admin obj)
        {
            accessContext.Entry<Admin>(obj).State = EntityState.Modified;
        }


        public void Delete(Admin obj)
        {
            accessContext.Admins.Remove(obj);
            accessContext.Entry<Admin>(obj).State = EntityState.Deleted;
        }

        public void Load()
        {
            accessContext.Admins.Load();
        }
    }
}
