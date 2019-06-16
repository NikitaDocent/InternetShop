using BLL.Managment;

namespace BLL.Find_and_Sort
{
    public class FindProduct
    {
        public string FindByName(ProductsManagment productsManagment,string key) => productsManagment.Find(x => x.Name == key).ToString();
        public string FindByType(ProductsManagment productsManagment, string key) => productsManagment.Find(x => x.Type == key).ToString();
        public string FindByCost(ProductsManagment productsManagment, int key) => productsManagment.Find(x => x.Cost == key).ToString();
        public string FindByCount(ProductsManagment productsManagment, int key) => productsManagment.Find(x => x.Count == key).ToString();
    }
}
