using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManagerPort.Model.ClassModel
{
    public class Port
    {
        public Port()
        {
            Trips = new Collection<Trip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1}\t{2:000000}", Id, Name, CityId);
        }
    }
}
