using System.Collections.Generic;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class PortRepository : IRepository<Port>
    {
        public List<Port> GetItemsList()
        {
            List<Port> ports;
            using (var managerPortContext = new ManagerPortContext())
            {
                ports = managerPortContext.Ports.ToList();
            }
            return ports;
        }

        public void Create(Port item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.Ports.Add(item);
                managerPortContext.SaveChanges();
            }
        }

        public void Update(Port item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = SearchById(item.Id);
                if (original != null)
                {
                    managerPortContext.Ports.Attach(original);
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
                    managerPortContext.Ports.Attach(item);
                    managerPortContext.Ports.Remove(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public Port SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.Ports.Find(id);
            }
        }
    }
}
