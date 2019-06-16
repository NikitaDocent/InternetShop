using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using DAL;
using Entity.Entitys;
using System.Data.Entity;

namespace TestCourseWork
{
    [TestFixture]
    public class DALTest
    {
        UnitOfWork unitOfWork = new UnitOfWork("userstore");
        [Test]
        public void TestInsertAdmin()
        {
            // Arrange 
            var adm = new Admin("oksi","2020");
            // Act 
            unitOfWork.Admins.Insert(adm);

            // Assert 
            Assert.AreEqual(adm, unitOfWork.Admins.GetAll().Last());
        }
        [Test]
        public void TestInsertClient()
        {
            // Arrange 
            var adm = new Client("oksi", "2020",200);
            // Act 
            unitOfWork.Clients.Insert(adm);

            // Assert 
            Assert.AreEqual(adm, unitOfWork.Clients.GetAll().Last());
        }
        [Test]
        public void TestInsertManager()
        {
            // Arrange 
            var adm = new Manager("oksi", "2020");
            // Act 
            unitOfWork.Managers.Insert(adm);

            // Assert 
            Assert.AreEqual(adm, unitOfWork.Managers.GetAll().Last());
        }
        [Test]
        public void TestInsertProduct()
        {
            // Arrange 
            var adm = new Product("", "kola","coca","i love it",10000,100);
            // Act 
            unitOfWork.Products.Insert(adm);

            // Assert 
            Assert.AreEqual(adm, unitOfWork.Products.GetAll().Last());
        }
        [Test]
        public void TestDeleteAdmin()
        {
            unitOfWork.Admins.Load();
            // Arrange 
            var adm = new Admin("oksi", "2020");
            unitOfWork.Admins.Insert(adm);
            // Act 
            unitOfWork.Admins.Delete(adm);
            // Assert
            if(unitOfWork.Admins.GetAll().ToList().Count != 0)
            Assert.AreNotEqual(adm, unitOfWork.Admins.GetAll().Last());
        }
        [Test]
        public void TestDeleteClient()
        {
            // Arrange 
            var adm = new Client("oksi", "2020",2000);
            unitOfWork.Clients.Insert(adm);
            // Act 
            unitOfWork.Clients.Delete(adm);
            // Assert 
            if (unitOfWork.Clients.GetAll().ToList().Count != 0)
            Assert.AreNotEqual(adm, unitOfWork.Clients.GetAll().Last());
        }
        [Test]
        public void TestDeleteManager()
        {
            // Arrange 
            var adm = new Manager("oksi", "2020");
            unitOfWork.Managers.Insert(adm);
            // Act 
            unitOfWork.Managers.Delete(adm);
            // Assert
            if (unitOfWork.Managers.GetAll().ToList().Count != 0)
            Assert.AreNotEqual(adm, unitOfWork.Managers.GetAll().Last());
        }
        [Test]
        public void TestDeleteProduct()
        {
            unitOfWork.Products.Load();
            // Arrange 
            var adm = new Product("", "kola", "coca", "i love it", 10000, 100);
            unitOfWork.Products.Insert(adm);
            // Act 
            unitOfWork.Products.Delete(adm);
            // Assert
            if (unitOfWork.Products.GetAll().ToList().Count != 0)
            Assert.AreNotEqual(adm,unitOfWork.Products.GetAll().Last());
        }
    }
}
