using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManagerPort.Model.ClassModel
{
    public class Captain
    {
        public Captain()
        {
            Trips = new Collection<Trip>();
            Ships = new Collection<Ship>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ShipId { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }


        public override string ToString()
        {
            return String.Format("{0:000000}  {1, 9}  {2,8}  {3,7}",Id,FirstName,LastName,ShipId);
        }
    }
}
