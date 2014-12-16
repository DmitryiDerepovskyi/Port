using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManagerPort.Model.ClassModel
{
    public class Trip
    {
        public Trip()
        {
            Cargos = new Collection<Cargo>();
        }

        public int Id { get; private set; }
        public int PortToId { get; set; }
        public int PortFromId { get; set; }
        public int CaptainId { get; set; }
        public int ShipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Captain Captain { get; set; }
        public virtual Ship Ship { get; set; }
        public virtual Port PortTo { get; set; }
        public virtual Port PortFrom { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }


        public override string ToString()
        {
            return String.Format("{0:000000}\t{1,6:000000}     {2,6:000000}     {3,6:000000}      {4,6:000000}    {5:d}   {6:d}"
                , Id, ShipId, CaptainId, PortToId, PortFromId, StartDate,EndDate);
        }
    }
}
