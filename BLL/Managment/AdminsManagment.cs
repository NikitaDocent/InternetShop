using System;
using System.Collections.Generic;
using BLL.Interface;
using Entity.Entitys;
using AutoMapper;
using DAL;

namespace BLL.Managment
{
    public class AdminsManagment : IManagment<Admin>
    {
        IMapper MAdmin = new MapperConfiguration(cfg => cfg.CreateMap<Admin, Admin>()).CreateMapper();
        private UnitOfWork unitOfWork { get; }

        public AdminsManagment()
        {
            unitOfWork = new UnitOfWork("ZakazOK");
        }

        public void Insert(Admin obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Admins.Insert(obj);
            SaveChanges();
        }

        public void Update(Admin obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Admins.Update(obj);
            SaveChanges();
        }

        public void Delete(Admin obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Admins.Delete(obj);
            SaveChanges();
        }

        public void Load() => unitOfWork.Admins.Load();

        public IEnumerable<Admin> Find(Func<Admin, bool> predicate) => unitOfWork.Admins.Find(predicate);

        public Admin GetItem(int id) => unitOfWork.Admins.Get(id);
        
        public List<Admin> GetList() => MAdmin.Map<IEnumerable<Admin>, List<Admin>>(unitOfWork.Admins.GetAll());
        
        public void SaveChanges() => unitOfWork.SaveChanges();
    }
}
