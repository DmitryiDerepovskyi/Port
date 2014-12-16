using System.Collections.Generic;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class TripRepository : IRepository<Trip>
    {

        public List<Trip> GetItemsList()
        {
            List<Trip> trips;
            using (var managerPortContext = new ManagerPortContext())
            {
                trips = managerPortContext.Trips.ToList();
            }
            return trips;
        }

        public void Create(Trip item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.Trips.Add(item);
                managerPortContext.SaveChanges();
            }
        }

        public void Update(Trip item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = SearchById(item.Id);
                if (original != null)
                {
                    managerPortContext.Trips.Attach(original);
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
                    managerPortContext.Trips.Attach(item);
                    managerPortContext.Trips.Remove(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public Trip SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.Trips.Find(id);
            }
        }
    }
}
