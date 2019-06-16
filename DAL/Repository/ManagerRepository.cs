using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using Entity.Entitys;
using System.Data.Entity;

namespace DAL.Repository
{
    public class ManagerRepository : IRepository<Manager>
    {
        private AccessContext accessContext;

        public ManagerRepository(AccessContext p_accessContext)
        {
            accessContext = p_accessContext;
        }

        public IEnumerable<Manager> Find(Func<Manager, bool> predicate)
        {
            return accessContext.Managers.Where(predicate).ToList();
        }

        public Manager Get(int id)
        {
            return accessContext.Managers.Find(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return accessContext.Managers.Local.ToBindingList();
        }

        public void Insert(Manager obj)
        {
            accessContext.Managers.Add(obj);
            accessContext.Entry(obj).State = EntityState.Added;
        }
        public void Update(Manager obj)
        {
            accessContext.Entry<Manager>(obj).State = EntityState.Modified;
        }


        public void Delete(Manager obj)
        {
            accessContext.Managers.Remove(obj);
            accessContext.Entry<Manager>(obj).State = EntityState.Deleted;
        }

        public void Load()
        {
            accessContext.Managers.Load();
        }
    }
}
