using BLL;
using BLL.Find_and_Sort;
using BLL.Managment;
using Entity.Entitys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace TestCourseWork
{
    [TestFixture]
    public class BLLTest
    {
        ClientsManagment clientsManagment = new ClientsManagment();
        AdminsManagment adminsManagment = new AdminsManagment();
        ManagersManagment managersManagement = new ManagersManagment();
        ProductsManagment productsManagment = new ProductsManagment();
        WorkShop work = new WorkShop();
        FindClient fc = new FindClient();
        FindManager fm = new FindManager();
        FindProduct fp = new FindProduct();
        SortProducts sp = new SortProducts();
        
        [TestMethod]
        public void TestMethod1()
        {
            
        }

        [Test]
        public void TestRegistryClient()
        {
            //Arange
            work.RegistryClient("Log", "0000", 10);
            //Act
            BLL.Managment.ClientsManagment clients = new BLL.Managment.ClientsManagment();
            clients.SaveChanges();
            clients.Load();
            // Assert 
            Assert.AreEqual("Log", clients.GetList().ElementAt(clients.GetList().Count-1).Email);
        }

        [Test]
        public void TestRegistryAdmin()
        {
            //Arange
            work.RegistryAdmin("Log", "0000");
            //Act
            BLL.Managment.AdminsManagment admins = new BLL.Managment.AdminsManagment();
            admins.SaveChanges();
            admins.Load();
            // Assert 
            Assert.AreEqual("Log", admins.GetList().ElementAt(admins.GetList().Count - 1).Email);
        }
        [Test]
        public void TestRegistryManager()
        {
            //Arange
            work.RegistryManager("Log", "0000");
            //Act
            BLL.Managment.ManagersManagment managers = new BLL.Managment.ManagersManagment();
            managers.SaveChanges();
            managers.Load();
            // Assert 
            Assert.AreEqual("Log", managers.GetList().ElementAt(managers.GetList().Count - 1).Email);
        }
        [Test]
        public void TestRegistryProduct()
        {
            //Arange
            work.RegistryProduct("Log", "0000", "dsf",100,10);
            //Act
            BLL.Managment.ProductsManagment products = new BLL.Managment.ProductsManagment();
            products.SaveChanges();
            products.Load();
            // Assert 
            Assert.AreEqual("Log", products.GetList().ElementAt(products.GetList().Count - 1).Name);
        }
        [Test]
        public void TestRemoveClient()
        {
            //Arange
            BLL.Managment.ClientsManagment clients = new BLL.Managment.ClientsManagment();
            Client cli = new Client("Oksi", "Buba", 1073);
            clients.Insert(cli);
            clients.SaveChanges();
            clients.Load();
            //Act
            clients.Delete(cli);
            // Assert 
            if (clients.GetList().Count != 0)
                Assert.AreNotEqual(cli, clients.GetList().ElementAt(clients.GetList().Count-1));
        }
        [Test]
        public void TestRemoveAdmin()
        {
            //Arange
            BLL.Managment.AdminsManagment admins = new BLL.Managment.AdminsManagment();
            Admin admi = new Admin("Oksi", "Buba");
            admins.Insert(admi);
            admins.SaveChanges();
            admins.Load();
            //Act
            admins.Delete(admi);
            // Assert 
            if (admins.GetList().Count != 0)
                Assert.AreNotEqual(admi, admins.GetList().ElementAt(admins.GetList().Count - 1));
        }
        [Test]
        public void TestRemoveManager()
        {
            //Arange
            BLL.Managment.ManagersManagment managers = new BLL.Managment.ManagersManagment();
            Manager manager = new Manager("Oksi", "Buba");
            managers.Insert(manager);
            managers.SaveChanges();
            managers.Load();
            //Act
            managers.Delete(manager);
            // Assert 
            if (managers.GetList().Count != 0)
                Assert.AreNotEqual(manager, managers.GetList().ElementAt(managers.GetList().Count - 1));
        }
        [Test]
        public void TestRemoveProduct()
        {
            //Arange
            BLL.Managment.ProductsManagment products = new BLL.Managment.ProductsManagment();
            Product product = new Product("", "Oksi", "Buba", "dfdsf",100,50);
            products.Insert(product);
            products.SaveChanges();
            products.Load();
            //Act
            products.Delete(product);
            // Assert 
            if (products.GetList().Count != 0)
                Assert.AreNotEqual(product, products.GetList().ElementAt(products.GetList().Count - 1));
        }

        [Test]
        public void FindByNameClient()
        {
            clientsManagment.Load();
            Client cli = new Client("Nik", "ghhghg", 1100);
            clientsManagment.Insert(cli);
            clientsManagment.SaveChanges();
            clientsManagment.Load();
            clientsManagment.Find(x => x.Email == "Nik");
            Assert.AreEqual(cli.Money, clientsManagment.Find(x => x.Email == "Nik").ElementAt(1).Money);

        }
        [Test]
        public void FindByNameAdmin()
        {
            adminsManagment.Load();
            Admin admin = new Admin("Nik", "ghhghg");
            adminsManagment.Insert(admin);
            adminsManagment.SaveChanges();
            adminsManagment.Load();
            adminsManagment.Find(x => x.Email == "Nik");
            Assert.AreEqual(admin.Email, adminsManagment.Find(x => x.Email == "Nik").ElementAt(0).Email);
        }
        [Test]
        public void FindByNameManager()
        {
            managersManagement.Load();
            Manager manager = new Manager("Nik", "ghhghg");
            managersManagement.Insert(manager);
            managersManagement.SaveChanges();
            managersManagement.Load();
            managersManagement.Find(x => x.Email == "Nik");
            Assert.AreEqual(manager.Email, managersManagement.Find(x => x.Email == "Nik").ElementAt(0).Email);
        }
        [Test]
        public void FindByNameProduct()
        {
            productsManagment.Load();
            Product products = new Product("","Nik", "ghhghg","nik",10,12);
            productsManagment.Insert(products);
            Product product = new Product("", "lll", "ghhghg", "nik", 10, 12);
            productsManagment.Insert(product);
            productsManagment.SaveChanges();
            productsManagment.Load();
            productsManagment.Find(x => x.Name == "lll");
            Assert.IsTrue(productsManagment.Find(x => x.Cost == product.Cost).Contains(product));

        }
        [Test]
        public void SortByNameProduct()
        {
            productsManagment.Load();
            productsManagment.Insert(new Product("", "av0", "bp", "kol", 125, 228));
            productsManagment.Insert(new Product("", "zd0", "klp", "uop", 5, 225));
            productsManagment.SaveChanges();
            productsManagment.Load();
            Assert.IsNotNull(work.SortByName());
        }
        [Test]
        public void TestGetInfoClient()
        {
            clientsManagment.Load();
            Client client = new Client("av0", "bp",228);
            clientsManagment.Insert(client);
            clientsManagment.SaveChanges();
            work.clientsManagment.Load();
            Assert.AreEqual(client.Money,work.GetInfoClient(work.clientsManagment.GetList().ElementAt(1).Id).Money);
        }
        [Test]
        public void TestGetInfoManager()
        {
            managersManagement.Load();
            Manager client = new Manager("av0", "bp");
            managersManagement.Insert(client);
            managersManagement.SaveChanges();
            work.managersManagment.Load();
            Assert.IsNotNull(work.GetInfoManager(work.managersManagment.GetList().Count-1));
        }
        [Test]
        public void TestGetInfoAdmin()
        {
            adminsManagment.Load();
            Admin client = new Admin("av0", "bp");
            adminsManagment.Insert(client);
            adminsManagment.SaveChanges();
            work.adminsManagment.Load();
            Assert.IsNotNull(work.GetInfoAdmin(work.adminsManagment.GetList().Count-1));
        }
        [Test]
        public void TestGetInfoProduct()
        {
            productsManagment.Load();
            Product client = new Product("125","124","av0", "bp",1245, 228);
            productsManagment.Insert(client);
            productsManagment.SaveChanges();
            work.productsManagment.Load();
            Assert.IsNotNull(work.GetInfoProduct(work.productsManagment.GetList().Count-1));
        }
        [Test]
        public void TestGetAllProduct()
        {
            productsManagment.Load();
            Product client = new Product("125", "124", "av0", "bp", 1245, 228);
            productsManagment.Insert(client);
            productsManagment.SaveChanges();
            work.productsManagment.Load();
            Assert.AreNotEqual("",work.GetProducts());
        }
        [Test]
        public void TestGetAllManager()
        {
            managersManagement.Load();
            Manager client = new Manager("125", "bp");
            managersManagement.Insert(client);
            managersManagement.SaveChanges();
            work.managersManagment.Load();
            Assert.AreNotEqual("",work.GetManagers());
        }
        [Test]
        public void TestGetAllAdmin()
        {
            adminsManagment.Load();
            Admin client = new Admin("bp", "1245");
            adminsManagment.Insert(client);
            adminsManagment.SaveChanges();
            work.adminsManagment.Load();
            Assert.AreNotEqual("",work.GetAdmins());
        }
        [Test]
        public void TestGetAllClient()
        {
            clientsManagment.Load();
            Client client = new Client("av0", "bp", 228);
            clientsManagment.Insert(client);
            clientsManagment.SaveChanges();
            work.clientsManagment.Load();
            Assert.AreNotEqual("", work.GetClients());
        }
        [Test]
        public void SortByName()
        {
            work.productsManagment.Load();
            Product p1 = new Product("a", "a", "a", "a", 15, 22);
            Product p2 = new Product("c", "c", "c", "c", 1245, 2028);
            Product p3 = new Product("b", "b", "b", "b", 145, 228);
            work.productsManagment.SaveChanges();
            work.productsManagment.Load();
            Assert.AreNotEqual("", work.SortByName());

        }
        [Test]
        public void SortByType()
        {
            work.productsManagment.Load();
            Product p1 = new Product("a", "a", "a", "a", 15, 22);
            Product p2 = new Product("c", "c", "c", "c", 1245, 2028);
            Product p3 = new Product("b", "b", "b", "b", 145, 228);
            work.productsManagment.SaveChanges();
            work.productsManagment.Load();
            Assert.AreNotEqual("", work.SortByType());

        }
        [Test]
        public void SortByCount()
        {
            work.productsManagment.Load();
            Product p1 = new Product("a", "a", "a", "a", 15, 22);
            Product p2 = new Product("c", "c", "c", "c", 1245, 2028);
            Product p3 = new Product("b", "b", "b", "b", 145, 228);
            work.productsManagment.SaveChanges();
            work.productsManagment.Load();
            Assert.AreNotEqual("", work.SortByCount());

        }
        [Test]
        public void SortByCost()
        {
            work.productsManagment.Load();
            Product p1 = new Product("a", "a", "a", "a", 15, 22);
            Product p2 = new Product("c", "c", "c", "c", 1245, 2028);
            Product p3 = new Product("b", "b", "b", "b", 145, 228);
            work.productsManagment.SaveChanges();
            work.productsManagment.Load();
            Assert.AreNotEqual("", work.SortByCost());

        }
    }
}
