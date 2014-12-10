using System;

namespace Port.Model.ClassModel
{
    public class Ship
    {
        public Ship(){}

        public Ship(int id,int number,int capacity,string dateCreate, int maxDistance,int teamCount)
        {
            Id = id;
            Number = number;
            Capacity = capacity;
            DateCreate = dateCreate;
            MaxDistance = maxDistance;
            TeamCount = teamCount;
        }

        public int Id { get; set; }
        public int CaptainId { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public string DateCreate { get; set; }
        public int MaxDistance { get; set; }
        public int TeamCount { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1:000000}\t   {2}\t   {3}   {4:d}\t{5}\t\t{6}"
                ,Id,CaptainId,Number,Capacity,DateTime.Parse(DateCreate),MaxDistance,TeamCount);
        }
    }
}
