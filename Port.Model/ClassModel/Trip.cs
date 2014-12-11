using System;

namespace Port.Model.ClassModel
{
    public class Trip
    {
        public Trip(){}

        public Trip(int id, int? shipId, int? captainId, int portFromId,int portToId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            PortToId = portToId;
            PortFromId = portFromId;
            StartDate = startDate;
            EndDate = endDate;
            CaptainId = captainId;
            ShipId = shipId;
        }

        public int Id { get; private set; }
        public int PortToId { get; set; }
        public int PortFromId { get; set; }
        public int? CaptainId { get; set; }
        public int? ShipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1,6:000000}     {2,6:000000}     {3,6:000000}      {4,6:000000}    {5:d}   {6:d}"
                , Id, ShipId, CaptainId, PortToId, PortFromId, StartDate,EndDate);
        }
    }
}
