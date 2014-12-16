using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class ShipRepository : IRepository<Ship>
    {
        public List<Ship> GetItemsList()
        {
            List<Ship> ships;
            using (var managerPortContext = new ManagerPortContext())
            {
                ships = managerPortContext.Ships.ToList();
            }
            return ships;
        }

        public void Create(Ship item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.Ships.Add(item);
                managerPortContext.SaveChanges();
                if (item.CaptainId != null)
                {
                    var repositoryCaptain = new CaptainRepository();
                    var captain = repositoryCaptain.SearchById((int)item.CaptainId);
                    captain.ShipId = (from ship in managerPortContext.Ships
                        select ship.Id).Max();
                    repositoryCaptain.Update(captain);
                }
            }
        }

        public void Update(Ship item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = SearchById(item.Id);
                if (original != null)
                {
                    var repositoryCaptain = new CaptainRepository();
                    Captain captain;
                    if (original.CaptainId != null)
                    {
                        captain = repositoryCaptain.SearchById((int)original.CaptainId);
                        captain.ShipId = null;
                        repositoryCaptain.Update(captain);
                    }
                    if (item.CaptainId != null)
                    {
                        captain = repositoryCaptain.SearchById((int)item.CaptainId);
                        captain.ShipId = item.Id;
                        repositoryCaptain.Update(captain);
                    }
                    managerPortContext.Ships.Attach(original);
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
                    if (item.CaptainId != null)
                    {
                        var repositoryCaptain = new CaptainRepository();
                        var captain = repositoryCaptain.SearchById((int)item.CaptainId);
                        captain.ShipId = null;
                        repositoryCaptain.Update(captain);
                    }
                    managerPortContext.Ships.Attach(item);
                    managerPortContext.Ships.Remove(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public Ship SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.Ships.Find(id);
            }
        }
    }
}
