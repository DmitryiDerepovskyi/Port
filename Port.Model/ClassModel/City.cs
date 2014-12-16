using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManagerPort.Model.ClassModel
{
    public class City
    {
        public City()
        {
            Ports = new Collection<Port>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Port> Ports { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1}",Id,Name);
        }
    }
}
