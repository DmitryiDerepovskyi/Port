using System;

namespace Port.Model.ClassModel
{
    public class Port
    {
        public Port(){}

        public Port(int id, string name, int cityId)
        {
            Id = id;
            Name = name;
            CityId = cityId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1}\t{2:000000}", Id, Name, CityId);
        }
    }
}
