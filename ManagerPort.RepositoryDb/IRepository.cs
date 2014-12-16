using System.Collections.Generic;

namespace ManagerPort.RepositoryDb
{
    public interface IRepository<T>
    {
        List<T> GetItemsList();
        void Create(T item);
        void Update(T item);
        void Remove(int id);
        T SearchById(int id);
    }
}
