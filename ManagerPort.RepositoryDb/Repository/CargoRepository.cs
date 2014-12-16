using System.Collections.Generic;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class CargoRepository : IRepository<Cargo>
    {

        public List<Cargo> GetItemsList()
        {
            List<Cargo> cargos;
            using (var managerPortContext = new ManagerPortContext())
            {
                cargos = managerPortContext.Cargos.ToList();
            }
            return cargos;
        }

        public void Create(Cargo item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.Cargos.Add(item);
                managerPortContext.SaveChanges();
            }
        }

        public void Update(Cargo item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = SearchById(item.Id);
                if (original != null)
                {
                    managerPortContext.Cargos.Attach(original);
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
                    managerPortContext.Cargos.Attach(item);
                    managerPortContext.Cargos.Remove(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public Cargo SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.Cargos.Find(id);
            }
        }
    }
}
