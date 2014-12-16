using System.Collections.Generic;
using System.Linq;
using ManagerPort.EF;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.RepositoryDb.Repository
{
    public class CityRepository : IRepository<City>
    {

        public List<City> GetItemsList()
        {
            List<City> cities;
            using (var managerPortContext = new ManagerPortContext())
            {
                cities = managerPortContext.Cities.ToList();
            }
            return cities;
        }

        public void Create(City item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                managerPortContext.Cities.Add(item);
                managerPortContext.SaveChanges();
            }
        }

        public void Update(City item)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                var original = SearchById(item.Id);
                if (original != null)
                {
                    managerPortContext.Cities.Attach(original);
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
                    managerPortContext.Cities.Attach(item);
                    managerPortContext.Cities.Remove(item);
                    managerPortContext.SaveChanges();
                }
            }
        }

        public City SearchById(int id)
        {
            using (var managerPortContext = new ManagerPortContext())
            {
                return managerPortContext.Cities.Find(id);
            }
        }
    }
}
