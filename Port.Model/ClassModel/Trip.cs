using System;

namespace Port.Model.ClassModel
{
    public class Trip
    {
        public Trip(){}

        public Trip(int id,int portToId,int portFromId,string startDate, string endDate, int captainId,int shipId)
        {
            Id = id;
            PortToId = portToId;
            PortFromId = portFromId;
            StartDate = startDate;
            EndDate = endDate;
            CaptainId = captainId;
            ShipId = shipId;
        }

        public int Id { get; set; }
        public int PortToId { get; set; }
        public int PortFromId { get; set; }
        public int CaptainId { get; set; }
        public int ShipId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1:000000}     {2:000000}     {3:000000}      {4:000000}    {5:d}   {6:d}"
                , Id, ShipId, CaptainId, PortToId, PortFromId, DateTime.Parse(StartDate), DateTime.Parse(EndDate));
        }
    }
}
