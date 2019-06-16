using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IManagment<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);

        void Load();
        void SaveChanges();

        List<T> GetList();
        T GetItem(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
