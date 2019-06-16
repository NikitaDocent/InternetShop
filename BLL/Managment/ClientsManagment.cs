using System;
using System.Collections.Generic;
using BLL.Interface;
using Entity.Entitys;
using AutoMapper;
using DAL;

namespace BLL.Managment
{
    public class ClientsManagment : IManagment<Client>
    {
        IMapper MClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, Client>()).CreateMapper();
        public UnitOfWork unitOfWork { get; }

        public ClientsManagment()
        {
            unitOfWork = new UnitOfWork("ZakazOK");
        }

        public void Insert(Client obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Clients.Insert(obj);
            SaveChanges();
        }

        public void Update(Client obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Clients.Update(obj);
            SaveChanges();
        }

        public void Delete(Client obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Clients.Delete(obj);
            SaveChanges();
        }

        public void Load() => unitOfWork.Clients.Load();

        public IEnumerable<Client> Find(Func<Client, bool> predicate) => unitOfWork.Clients.Find(predicate);

        public Client GetItem(int id) => unitOfWork.Clients.Get(id);

        public List<Client> GetList()
        {
            return MClient.Map<IEnumerable<Client>, List<Client>>(unitOfWork.Clients.GetAll());
        }
        public void SaveChanges() => unitOfWork.SaveChanges();
    }
}
