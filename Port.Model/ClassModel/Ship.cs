using System;

namespace Port.Model.ClassModel
{
    public class Ship
    {
        public Ship(){}

        public Ship(int id, int? captainId, int number,int capacity,DateTime dateCreate, int maxDistance,int teamCount)
        {
            Id = id;
            CaptainId = captainId;
            Number = number;
            Capacity = capacity;
            DateCreate = dateCreate;
            MaxDistance = maxDistance;
            TeamCount = teamCount;
        }

        public int Id { get; private set; }
        public int? CaptainId { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public DateTime DateCreate { get; set; }
        public int MaxDistance { get; set; }
        public int TeamCount { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1,9:000000}  {2,6}  {3,8}  {4:d}  {5,11}  {6,8}"
                ,Id,CaptainId,Number,Capacity, DateCreate,MaxDistance,TeamCount);
        }
    }
}
