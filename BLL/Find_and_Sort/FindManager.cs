using BLL.Managment;

namespace BLL.Find_and_Sort
{
    public class FindManager
    {
        public string FindByName(ManagersManagment managersManagment, string key) => managersManagment.Find(x => x.Email == key).ToString();
    }
}
