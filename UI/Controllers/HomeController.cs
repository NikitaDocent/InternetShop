using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entity.Entitys;
using BLL.Managment;
using AutoMapper;
using UI.Models;
using BLL.Statistic;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        WorkShop Shop = new WorkShop();
        ClientsManagment Clients = new ClientsManagment();
        Stats stats = new Stats();
        
        public ActionResult Index()
        {
            ViewBag.Title = "ZakazOK";
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }

            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult ClientView(int cli)
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }

            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            ViewBag.Client = cli;
            return View();
        }

        public ActionResult ProfileManeger()
        {

            Shop.clientsManagment.Load();
            IMapper MClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, MClient>()).CreateMapper();
            ViewBag.Clients = MClient.Map<List<Client>, IEnumerable<MClient>>(Shop.clientsManagment.GetList());
            Shop.managersManagment.Load();
            IMapper Mmanager = new MapperConfiguration(cfg => cfg.CreateMap<Manager, MManager>()).CreateMapper();
            ViewBag.Managers = Mmanager.Map<List<Manager>, IEnumerable<MManager>>(Shop.managersManagment.GetList());
            int cont = 0;
            List<string> ts = new List<string>();
            foreach (var item in Shop.clientsManagment.GetList())
            {
                ts.Add("User:\t" + item.Email + "\tBuys: " + item.Books);
                cont += item.Books;
            }
            stats.CountOfUsers = Shop.managersManagment.GetList().Count + Shop.clientsManagment.GetList().Count;
            stats.CountOfBuys = cont;
            ts.Add("Registred Users : " + stats.CountOfUsers);
            ts.Add("All users Buys: " + stats.CountOfBuys);
            ViewBag.Statistic = ts;
            return View();
        }

        public ActionResult Profile(int Id)
        {
            Shop.clientsManagment.Load();
            IMapper MClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, MClient>()).CreateMapper();
            ViewBag.Clients = MClient.Map<List<Client>, IEnumerable<MClient>>(Shop.clientsManagment.GetList());
            List<string> ts = new List<string>();
            ts.Add("My Buys: " + Shop.clientsManagment.Find(x=>x.Id == Id).ElementAt(0).Books);
            ViewBag.Statistic = ts;
            ViewBag.Person = Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0);
            return View();
        }

        public ActionResult AddMoney(int Id )
        {
            return View();
        }
        [HttpPost]
        public ActionResult Profile(int Id,string password, int sum)
        {
            Shop.clientsManagment.Load();
            Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0).Parol = password;
            Shop.clientsManagment.SaveChanges();
            Shop.clientsManagment.Update(Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0));
            Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0).Money += sum;
            Shop.clientsManagment.SaveChanges();
            Shop.clientsManagment.Update(Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0));
            return RedirectToAction("Profile",new { Id = Id});
        }
      /*  [HttpPost]
        public ActionResult Profile(int Id, int sum)
        {
            Shop.clientsManagment.Load();
            Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0).Money += sum;
            Shop.clientsManagment.SaveChanges();
            Shop.clientsManagment.Update(Shop.clientsManagment.Find(x => x.Id == Id).ElementAt(0));
            return RedirectToAction("Profile", new { Id = Id });
        }
        */

        public void AddAssortiment()
        {
           // Shop.adminsManagment.Insert(new Admin("Admin@admin.com", "123456789"));
           // Shop.adminsManagment.SaveChanges();
           // Shop.managersManagment.Insert(new Manager("Manager@manager.com", "987654321"));
           // Shop.managersManagment.SaveChanges();
            MProduct p1 = new MProduct("https://pp.vk.me/c623816/v623816451/44aa4/aR6mhErZ4SM.jpg","Boots", "Adiddas", "This is best boots in the world", 1000, 5);
            MProduct p2 = new MProduct("https://www.castlerock.ru/upload/iblock/307/30715cc6e34c2c07e041f87488cb0bf7.jpg", "Bag", "BAdVAg", "This is worst bag in the world", 500, 3);
            MProduct p3 = new MProduct("http://kepik.ru/upload/img_kepki/original/32/32-14054536541.jpg", "Hat", "BatHat", "This is best hat in the world", 1000, 5);
            MProduct p4 = new MProduct("https://images.ua.prom.st/863588412_gorodskoj-ryukzak-kosmos.jpg","Bag", "SpaceBag", "This is worst bag in the world", 500, 3);
            MProduct p5 = new MProduct("https://upload.wikimedia.org/wikipedia/commons/thumb/c/c0/Nike_Air_Max_Plus_Tuned_%282018%29.jpg/220px-Nike_Air_Max_Plus_Tuned_%282018%29.jpg","Boots", "CoolBag", "This is best bag in the world", 1000, 5);
            MProduct p6 = new MProduct("https://images.ua.prom.st/1424369332_tovar-s-defektom.jpg", "Bag", "S defectom Bag", "This is worst bag in the world", 500, 3);
            MProduct p7 = new MProduct("https://nazya.com/anyimage/img02.taobaocdn.com/bao/uploaded/i2/1064525228/T2KHC2Xe4aXXXXXXXX_!!1064525228.jpg", "Boots", "AddiBoots", "This is best bag in the world", 1000, 5);
            MProduct p8 = new MProduct("https://super01.ru/pictures/product/big/37893_big.jpg", "Hat", "GameThronesDragonHat", "This is worst bag in the world", 500, 3);
            MProduct p9 = new MProduct("https://media2.24aul.ru/imgs/58f720f673fce82c1cb5fb97/", "Boots", "Balenciaga", "This is best bag in the world", 1000, 5);
            MProduct p10 = new MProduct("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTChy0JijHhWps6Q1f7G2GyDO_1Gv36k_oHXnOJGKtgaMar8vF5-g", "Boots", "NikeBoots", "This is worst bag in the world", 500, 3);
            MProduct p11 = new MProduct("https://mayki.kz/catalog_img/884484/caps/1_2_zoom.png","Hat", "DuckBlya", "This is best bag in the world", 1000, 5);
            MProduct p12 = new MProduct("https://img2.traektoria.ru/upload/resize_cache/iblock/aa6/560_560_1/aa64f2bb7c75b10592188f0d9563880e.jpg","Hat", "Trasher", "This is worst bag in the world", 500, 3);
            MProduct p13 = new MProduct("https://images.ua.prom.st/1538689372_w640_h640_krutye-muzhskie-krossovki.jpg", "Boots", "RedBoots", "This is best bag in the world", 1000, 5);
            MProduct p14 = new MProduct("https://images.ua.prom.st/1035264279_muzhskie-krossovki-balenciaga.jpg", "Boots", "BlanciagaKatya", "This is worst bag in the world", 500, 3);
            MProduct p15 = new MProduct("https://storage.vsemayki.ru/images/0/0/153/153046/previews/people_110_caps_front_black_500.jpg", "Hat", "Ты меня не стоишь.", "This is best bag in the world", 1000, 5);
            MProduct p16 = new MProduct("https://images.ua.prom.st/879716278_w640_h640_pudrovyj-ryukzak-kotik.jpg", "Bag", "CatBag", "This is worst bag in the world", 500, 3);
            MProduct p17 = new MProduct("https://i1.rozetka.ua/goods/9230052/38965960_images_9230052636.jpg", "Bag", "Winter is comming BAG", "This is best bag in the world", 1000, 5);
            MProduct p18 = new MProduct("https://i1.rozetka.ua/goods/11227093/37328024_images_11227093701.jpg", "Bag", "AntiZiefBag", "This is worst bag in the world", 500, 3);
            MProduct p19 = new MProduct("https://images.izi.zone/300802", "Boots", "NikeAIR", "This is best bag in the world", 1000, 5);
            MProduct p20 = new MProduct("https://cdn-images.farfetch-contents.com/12/33/67/14/12336714_11033536_480.jpg","Hat", "GucciHat", "This is worst bag in the world", 500, 3);

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<MProduct, Product>()).CreateMapper();

            Shop.productsManagment.Insert(mapper.Map<MProduct,Product>(p1));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p2));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p3));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p4));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p5));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p6));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p7));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p8));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p9));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p10));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p11));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p12));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p13));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p14));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p15));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p16));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p17));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p18));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p19));
            Shop.productsManagment.Insert(mapper.Map<MProduct, Product>(p20));
            Shop.productsManagment.SaveChanges();
        }

        public ActionResult Test()
        {

            AddAssortiment();
            Shop.productsManagment.Load();
              List<Product> p1 = new List<Product>();
              List<Product> p2 = new List<Product>();
              List<Product> p3 = new List<Product>();
              List<Product> p4 = new List<Product>();
              for (int i = 0; i < 5; i++)
              {
                  p1.Add(Shop.productsManagment.GetList().ElementAt(i));
              }
              for (int i = 5; i < 10; i++)
              {
                  p2.Add(Shop.productsManagment.GetList().ElementAt(i));
              }
              for (int i = 10; i < 15; i++)
              {
                  p3.Add(Shop.productsManagment.GetList().ElementAt(i));
              }
              for (int i = 15; i < 20; i++)
              {
                  p4.Add(Shop.productsManagment.GetList().ElementAt(i));
              }

              ViewBag.Prod1 = p1;
              ViewBag.Prod2 = p2;
              ViewBag.Prod3 = p3;
              ViewBag.Prod4 = p4;
            ViewBag.Products = Shop.productsManagment.GetList();
            return View();
        }

        public ActionResult Delete(int id)
        {
            Shop.clientsManagment.Load();
            IMapper MClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, MClient>()).CreateMapper();
            MClient b = MClient.Map<Client, MClient>(Shop.clientsManagment.Find(x=>x.Id == id).ElementAt(0));
            if (b != null)
            {
                Shop.clientsManagment.Delete(Shop.clientsManagment.Find(x => x.Id == id).ElementAt(0));
                Shop.clientsManagment.SaveChanges();
            }
            return RedirectToAction("ProfileAdmin");
        }

        public ActionResult Buy(int id,int cli)
        {
            Shop.clientsManagment.Load();
            Shop.productsManagment.Load();
            Product b = Shop.productsManagment.Find(x => x.Id == id).ElementAt(0);
            if (b.Count > 0 || b.Cost > Shop.clientsManagment.Find(x => x.Id == cli).ElementAt(0).Money)
            {
                b.Count -= 1;
                Shop.clientsManagment.Find(x=> x.Id == cli).ElementAt(0).Books += 1;
                Shop.clientsManagment.Find(x => x.Id == cli).ElementAt(0).Money -= b.Cost;
                ViewBag.Message = "Success buy!";

            }
            else
                ViewBag.Message = "You'are cant buy now";

            if (b != null)
            {
                Shop.productsManagment.SaveChanges();
                Shop.clientsManagment.SaveChanges();
                Shop.productsManagment.Update(b);
                Shop.clientsManagment.Update(Shop.clientsManagment.Find(x => x.Id == cli).ElementAt(0));
            }
            return RedirectToAction("ClientView", new { cli = Shop.clientsManagment.Find(x => x.Id == cli).ElementAt(0).Id });

        }

        public ActionResult MDelete(int id)
        {
            Shop.managersManagment.Load();
            IMapper Mmanager = new MapperConfiguration(cfg => cfg.CreateMap<Manager, MManager>()).CreateMapper();
            MManager b = Mmanager.Map<Manager, MManager>(Shop.managersManagment.Find(x => x.Id == id).ElementAt(0));
            if (b != null)
            {
                Shop.managersManagment.Delete(Shop.managersManagment.Find(x => x.Id == id).ElementAt(0));
                Shop.managersManagment.SaveChanges();
            }
            return RedirectToAction("ProfileAdmin");
        }

        public ActionResult ProfileAdmin()
        {
            Shop.clientsManagment.Load();
            IMapper MClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, MClient>()).CreateMapper();
            ViewBag.Clients = MClient.Map<List<Client>,IEnumerable<MClient>>(Shop.clientsManagment.GetList());
            Shop.managersManagment.Load();
            IMapper Mmanager = new MapperConfiguration(cfg => cfg.CreateMap<Manager, MManager>()).CreateMapper();
            ViewBag.Managers = Mmanager.Map<List<Manager>, IEnumerable<MManager>>(Shop.managersManagment.GetList());
            int cont = 0;
            foreach (var item in Shop.clientsManagment.GetList())
                cont += item.Books;
            stats.CountOfUsers = Shop.managersManagment.GetList().Count + Shop.clientsManagment.GetList().Count;
            stats.CountOfBuys = cont;
            List<string> ts = new List<string>();
            ts.Add("Registred Users : " + stats.CountOfUsers);
            ts.Add("All Buys: " + stats.CountOfBuys);
            ViewBag.Statistic = ts;
            return View();
        }


        public ActionResult Hat()
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            foreach (var a in Shop.productsManagment.GetList())
            {
                if (a.Type == "Hat")
                    p3.Add(a);
            }
            for (int i = 0; i < 2; i++)
            {
                p1.Add(p3.ElementAt(i));
            }
            for (int i = 2; i < 4; i++)
            {
                p2.Add(p3.ElementAt(i));
            }
            for (int i = 4; i < 6; i++)
            {
                p4.Add(p3.ElementAt(i));
            }
            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p4;
            return View();
        }

        public ActionResult Boots()
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            foreach (var a in Shop.productsManagment.GetList())
            {
                if (a.Type == "Boots")
                    p3.Add(a);
            }
            for (int i = 0; i < 3; i++)
            {
                p1.Add(p3.ElementAt(i));
            }
            for (int i = 3; i < 6; i++)
            {
                p2.Add(p3.ElementAt(i));
            }
            for (int i = 6; i < 8; i++)
            {
                p4.Add(p3.ElementAt(i));
            }
            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p4;
            return View();
        }

        public ActionResult AdminView()
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            List<Product> p5 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 20; i < Shop.productsManagment.GetList().Count - 1 ; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            ViewBag.Prod5 = p5;
            return View();
        }
        [HttpPost]
        public ActionResult AdminView(string http, string type, string name, string description, int cost, int scount)
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            List<Product> p5 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 20; i < 22; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            ViewBag.Prod5 = p5;
            Shop.productsManagment.Insert(new Product(http, type, name, description, cost, scount));
            Shop.productsManagment.SaveChanges();
            return RedirectToAction("AdminView");
        }
        /*
        public ActionResult AdminView(int Id, int count)
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            List<Product> p5 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 20; i < Shop.productsManagment.GetList().Count - 1; i++)
            {
                p5.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            ViewBag.Prod5 = p5;
            return RedirectToAction("AdminView");
        }*/
        public ActionResult ManagerView()
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }

            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            return View();
        }
        [HttpPost]
        public ActionResult ManagerView(int Id, int count,int sum)
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                p1.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 5; i < 10; i++)
            {
                p2.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 10; i < 15; i++)
            {
                p3.Add(Shop.productsManagment.GetList().ElementAt(i));
            }
            for (int i = 15; i < 20; i++)
            {
                p4.Add(Shop.productsManagment.GetList().ElementAt(i));
            }

            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p3;
            ViewBag.Prod4 = p4;
            Shop.productsManagment.Find(x => x.Id == Id).ElementAt(0).Count += count;
            Shop.productsManagment.Find(x => x.Id == Id).ElementAt(0).Cost = sum;
            Shop.productsManagment.SaveChanges();
            Shop.productsManagment.Update(Shop.productsManagment.Find(x => x.Id == Id).ElementAt(0));
            return RedirectToAction("ManagerView");
        }

        public ActionResult Bags()
        {
            Shop.productsManagment.Load();
            List<Product> p1 = new List<Product>();
            List<Product> p2 = new List<Product>();
            List<Product> p3 = new List<Product>();
            List<Product> p4 = new List<Product>();
            foreach (var a in Shop.productsManagment.GetList())
            {
                if (a.Type == "Bag")
                    p3.Add(a);
            }
            for (int i = 0; i < 2; i++)
            {
                p1.Add(p3.ElementAt(i));
            }
            for (int i = 2; i < 4; i++)
            {
                p2.Add(p3.ElementAt(i));
            }
            for (int i = 4; i < 6; i++)
            {
                p4.Add(p3.ElementAt(i));
            }
            ViewBag.Prod1 = p1;
            ViewBag.Prod2 = p2;
            ViewBag.Prod3 = p4;
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string email, string password)
        {
            ClientsManagment var = new ClientsManagment();
            // Shop.RegistryClient(email, password, 510);
            var.unitOfWork.Clients.Insert(new Client(email, password, 5120));
            var.SaveChanges();
            var.Load();
            ViewBag.Message = "Succesfully registred";
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
           ClientsManagment var = new ClientsManagment();
            AdminsManagment adm = new AdminsManagment();
            ManagersManagment mag = new ManagersManagment();
            adm.Load();
            mag.Load();
            var.Load();
            var listUsers = var.GetList();
            
            string role = "nope";
            foreach (Client u in  listUsers)
            {
                if (u.Email.Equals(email) && u.Parol.Equals(password))
                {
                    role = "Client";
                }
            }
            var listManagers = mag.GetList();
            foreach (Manager u in listManagers)
            {
                if (u.Email.Equals(email) && u.Parol.Equals(password))
                {
                    role = "Manager";
                }
            }
            var listAdmin = adm.GetList();
            foreach (Admin u in listAdmin)
            {
                if (u.Email.Equals(email) && u.Parol.Equals(password))
                {
                    role = "Admin";
                }
            }

            if (role.Equals("Client"))
            {
                return RedirectToAction("ClientView", new { cli = Shop.clientsManagment.Find(x => x.Email == email).ElementAt(0).Id });
            } else if (role.Equals("Admin"))
                return RedirectToAction("AdminView");
            else if (role.Equals("Manager"))
                return RedirectToAction("ManagerView");
            else
            {
                ViewBag.Message = "Incorrect login or password, try again";
                return View();
            }
                
        }
        [HttpGet]
        public ActionResult Search(string search)
        {
            ViewBag.Message = search;
            
            return RedirectToAction(search);
        }
    }
}
