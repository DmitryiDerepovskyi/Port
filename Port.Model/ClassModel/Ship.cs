using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManagerPort.Model.ClassModel
{
    public class Ship
    {
        public Ship()
        {
            Trips = new Collection<Trip>();
        }

        public int Id { get; set; }
        public int? CaptainId { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public DateTime DateCreate { get; set; }
        public int MaxDistance { get; set; }
        public int TeamCount { get; set; }

        public virtual Captain Captain { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1,9:000000}  {2,6}  {3,8}  {4:d}  {5,11}  {6,8}"
                ,Id,CaptainId,Number,Capacity, DateCreate,MaxDistance,TeamCount);
        }
    }
}
