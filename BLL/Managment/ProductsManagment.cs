using System;
using System.Collections.Generic;
using BLL.Interface;
using Entity.Entitys;
using AutoMapper;
using DAL;

namespace BLL.Managment
{
    public class ProductsManagment : IManagment<Product>
    {
        IMapper MProduct = new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>()).CreateMapper();
        private UnitOfWork unitOfWork { get; }

        public ProductsManagment()
        {
            unitOfWork = new UnitOfWork("ZakazOK");
        }

        public void Insert(Product obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Products.Insert(obj);
            SaveChanges();
        }

        public void Update(Product obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Products.Update(obj);
            SaveChanges();
        }

        public void Delete(Product obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Products.Delete(obj);
            SaveChanges();
        }

        public void Load() => unitOfWork.Products.Load();

        public IEnumerable<Product> Find(Func<Product, bool> predicate) => unitOfWork.Products.Find(predicate);

        public Product GetItem(int id) => unitOfWork.Products.Get(id);
        
        public List<Product> GetList() => MProduct.Map<IEnumerable<Product>, List<Product>>(unitOfWork.Products.GetAll());
        
        public void SaveChanges() => unitOfWork.SaveChanges();
    }
}
