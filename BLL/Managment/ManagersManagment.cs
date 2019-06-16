using System;
using System.Collections.Generic;
using BLL.Interface;
using Entity.Entitys;
using AutoMapper;
using DAL;

namespace BLL.Managment
{
    public class ManagersManagment : IManagment<Manager>
    {
        IMapper MManager = new MapperConfiguration(cfg => cfg.CreateMap<Manager, Manager>()).CreateMapper();
        private UnitOfWork unitOfWork { get; }

        public ManagersManagment()
        {
            unitOfWork = new UnitOfWork("ZakazOK");
        }

        public void Insert(Manager obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Managers.Insert(obj);
            SaveChanges();
        }

        public void Update(Manager obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Managers.Update(obj);
            SaveChanges();
        }

        public void Delete(Manager obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Managers.Delete(obj);
            SaveChanges();
        }

        public void Load() => unitOfWork.Managers.Load();

        public IEnumerable<Manager> Find(Func<Manager, bool> predicate) => unitOfWork.Managers.Find(predicate);

        public Manager GetItem(int id) => unitOfWork.Managers.Get(id);
     
        public List<Manager> GetList() => MManager.Map<IEnumerable<Manager>, List<Manager>>(unitOfWork.Managers.GetAll());
        

        public void SaveChanges() => unitOfWork.SaveChanges();
    }
}
