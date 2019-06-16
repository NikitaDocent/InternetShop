using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using Entity.Entitys;
using System.Data.Entity;

namespace DAL.Repository
{
    public class ProductRepository : IRepository<Product>
    {

        private AccessContext accessContext;

        public ProductRepository(AccessContext p_accessContext)
        {
            accessContext = p_accessContext;
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return accessContext.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            return accessContext.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return accessContext.Products.Local.ToBindingList();
        }

        public void Insert(Product obj)
        {
            accessContext.Products.Add(obj);
            accessContext.Entry(obj).State = EntityState.Added;
        }
        public void Update(Product obj)
        {
            accessContext.Entry<Product>(obj).State = EntityState.Modified;
        }


        public void Delete(Product obj)
        {
            accessContext.Products.Remove(obj);
            accessContext.Entry<Product>(obj).State = EntityState.Deleted;
        }

        public void Load()
        {
            accessContext.Products.Load();
        }
    }
}
