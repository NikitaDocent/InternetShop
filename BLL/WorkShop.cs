using System;
using System.Linq;
using BLL.Find_and_Sort;
using BLL.Managment;
using Entity.Entitys;
using BLL.Exeptions;
using BLL.Statistic;
using System.Collections.Generic;

namespace BLL
{
    public class WorkShop
    {
        private Stats stats = new Stats();
        private FindClient findC = new FindClient();
        private FindManager findM = new FindManager();
        private FindProduct findP = new FindProduct();
        private SortProducts sort = new SortProducts();
        public ClientsManagment clientsManagment = new ClientsManagment();
        public AdminsManagment adminsManagment = new AdminsManagment();
        public ManagersManagment managersManagment = new ManagersManagment();
        public ProductsManagment productsManagment = new ProductsManagment();

        //добавление
        #region Add
        public void RegistryClient(string login, string parol, int mon) => clientsManagment.Insert(new Client
        {
            Email = String.IsNullOrEmpty(login.Trim()) ? throw new ClientException("Invald Email") : login,
            Parol = String.IsNullOrEmpty(parol.Trim()) ? throw new ClientException("Invalid parol") : parol,
            Money = mon < 0 ? throw new ClientException("Invalid money") : mon,
        });
        public void RegistryAdmin(string login, string parol) => adminsManagment.Insert(new Admin
        {
            Email = String.IsNullOrEmpty(login.Trim()) ? throw new AdminException("Invald Email") : login,
            Parol = String.IsNullOrEmpty(parol.Trim()) ? throw new AdminException("Invalid parol") : parol,
        });
        public void RegistryManager(string login, string parol) => managersManagment.Insert(new Manager
        {
            Email = String.IsNullOrEmpty(login.Trim()) ? throw new ManagerExeption("Invald Email") : login,
            Parol = String.IsNullOrEmpty(parol.Trim()) ? throw new ManagerExeption("Invalid parol") : parol,
        });
        public void RegistryProduct(string name, string type, string description, int cost, int count) => productsManagment.Insert(new Product
        {
            Name = String.IsNullOrEmpty(name.Trim()) ? throw new ProductExeption("Invald name") : name,
            Type = String.IsNullOrEmpty(type.Trim()) ? throw new ProductExeption("Invalid type") : type,
            Description = String.IsNullOrEmpty(description.Trim()) ? throw new ProductExeption("Invalid description") : description,
            Cost = cost < 0 ? throw new ProductExeption("Invalid cost") : cost,
            Count = count < 0 ? throw new ProductExeption("Invalid count") : count
        });
        #endregion
        
        //Получить информацию об об'екте
        #region GetInfo
        public Client GetInfoClient(int ind)
        {
            if (ind <= 0 || ind > clientsManagment.GetList().Count)
                throw new ClientException("Index out of range");
            return ind <= 0 || ind > clientsManagment.GetList().Count ? null : clientsManagment.GetItem(ind);
        }
        public Admin GetInfoAdmin(int ind)
        {
            if (ind <= 0 || ind > adminsManagment.GetList().Count)
                throw new ClientException("Index out of range");
            return ind <= 0 || ind > adminsManagment.GetList().Count ? null : adminsManagment.GetItem(ind);
        }
        public Manager GetInfoManager(int ind)
        {
            if (ind <= 0 || ind > managersManagment.GetList().Count)
                throw new ClientException("Index out of range");
            return ind <= 0 || ind > managersManagment.GetList().Count ? null : managersManagment.GetItem(ind);
        }
        public Product GetInfoProduct(int ind)
        {
            if (ind <= 0 || ind > productsManagment.GetList().Count)
                throw new ClientException("Index out of range");
            return ind <= 0 || ind > productsManagment.GetList().Count ? null : productsManagment.GetItem(ind);
        }
        #endregion
        //Получить список 
        #region GetAll
        public string GetClients()
        {
            int cnt = 1; string result = "";
            foreach (Client client in clientsManagment.GetList())
            {
                result += cnt + ".\t" + client.ToString() + "\n";
                cnt++;
            }
            return result;
        }
        public List<string> GetAdmins()
        {
            List<string> adm = new List<string>();
            int cnt = 1; string result = "";
            foreach (Admin ad in adminsManagment.GetList())
            {
                result = cnt + ".\t" + ad.ToString() + "\n";
                adm.Add(result);
                cnt++;
            }
            return adm;
        }
        public string GetManagers()
        {
            int cnt = 1; string result = "";
            foreach (Manager manager in managersManagment.GetList())
            {
                result += cnt + ".\t" + manager.ToString() + "\n";
                cnt++;
            }
            return result;
        }
        public string GetProducts()
        {
            int cnt = 1; string result = "";
            foreach (Product product in productsManagment.GetList())
            {
                result += cnt + ".\t" + product.ToString() + "\n";
                cnt++;
            }
            return result;
        }
        #endregion
        //Sort Products
        #region Sort
        public string SortByName()
        {
            string result = "";
           foreach(Product prod in sort.SortByName(productsManagment))
            {
                result += prod.ToString() + "\n";
            }
            return result;

        }
        public string SortByType()
        {
            string result = "";
            foreach (Product prod in sort.SortByType(productsManagment))
            {
                result += prod.ToString() + "\n";
            }
            return result;
        }
        public string SortByCount()
        {
            string result = "";
            foreach (Product prod in sort.SortByCount(productsManagment))
            {
                result += prod.ToString() + "\n";
            }
            return result;
        }
        public string SortByCost()
        {
            string result = "";
            foreach (Product prod in sort.SortByCost(productsManagment))
            {
                result += prod.ToString() + "\n";
            }
            return result;
        }
        #endregion        
    }
}
