using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Managment;
using Entity.Entitys;

namespace BLL.Find_and_Sort
{
    public class SortProducts
    {
        public List<Product> SortByName(ProductsManagment productsManagment)
        {
            var temp = productsManagment.GetList();
            for (int i = 0; i < productsManagment.GetList().Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < productsManagment.GetList().Count; j++)
                    if (temp[j].Name.CompareTo(temp[min].Name) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        public List<Product> SortByType(ProductsManagment productsManagment)
        {
            var temp = productsManagment.GetList();
            for (int i = 0; i < productsManagment.GetList().Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < productsManagment.GetList().Count; j++)
                    if (temp[j].Type.CompareTo(temp[min].Type) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        public List<Product> SortByCost(ProductsManagment productsManagment)
        {
            var temp = productsManagment.GetList();
            for (int i = 0; i < productsManagment.GetList().Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < productsManagment.GetList().Count; j++)
                    if (temp[j].Cost.CompareTo(temp[min].Cost) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        public List<Product> SortByCount(ProductsManagment productsManagment)
        {
            var temp = productsManagment.GetList();
            for (int i = 0; i < productsManagment.GetList().Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < productsManagment.GetList().Count; j++)
                    if (temp[j].Count.CompareTo(temp[min].Count) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
    }
}
