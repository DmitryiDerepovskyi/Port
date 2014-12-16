using System.Collections.Generic;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class TypeCargoRepository : IRepository<TypeCargo>
    {
        public List<TypeCargo> GetItemsList()
        {
            List<TypeCargo> types;
            using (var managerPortContext = new ManagerPortContext())
            {
                types = managerPortContext.TypesCargo.ToList();
            }
            return types;
        }

        public void Create(TypeCargo item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.TypesCargo.Add(item);
                managerPortContext.SaveChanges();
            }
        }

        public void Update(TypeCargo item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = SearchById(item.Id);
                if (original != null)
                {
                    managerPortContext.TypesCargo.Attach(original);
                    managerPortContext.Entry(original).CurrentValues.SetValues(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public void Remove(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var item = SearchById(id);
                if (item != null)
                {
                    managerPortContext.TypesCargo.Attach(item);
                    managerPortContext.TypesCargo.Remove(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public TypeCargo SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.TypesCargo.Find(id);
            }
        }
    }
}
