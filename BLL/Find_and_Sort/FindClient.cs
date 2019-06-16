using BLL.Managment;

namespace BLL.Find_and_Sort
{
    public class FindClient
    {
        public string FindByName(ClientsManagment clientsManagment, string key) => clientsManagment.Find(x => x.Email == key).ToString();
        public string FindByMoney(ClientsManagment clientsManagment, int key) => clientsManagment.Find(x => x.Money == key).ToString();
    }
}
