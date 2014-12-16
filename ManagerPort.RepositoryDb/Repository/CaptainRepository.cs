using System.Collections.Generic;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class CaptainRepository : IRepository<Captain>
    {
        public List<Captain> GetItemsList()
        {
            List<Captain> captains;
            using (var managerPortContext = new ManagerPortContext())
            {
                captains = managerPortContext.Captains.ToList();
            }
            return  captains;
        }

        public void Create(Captain item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.Captains.Add(item);
                managerPortContext.SaveChanges();
            }
        }

        public void Update(Captain item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = managerPortContext.Captains.Find(item.Id);
                if (original != null)
                {
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
                    managerPortContext.Captains.Attach(item);
                    managerPortContext.Captains.Remove(item);
                    if (item.ShipId != null)
                    {
                        var repositoryShip = new ShipRepository();
                        var ship = repositoryShip.SearchById((int)item.ShipId);
                        ship.CaptainId = null;
                        repositoryShip.Update(ship);
                    }
                    managerPortContext.SaveChanges();
                }
            }
        }

        public Captain SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.Captains.Find(id);
            }
        }
    }
}
