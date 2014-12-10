using System;

namespace Port.Model.ClassModel
{
    public class City
    {
        public City(){}

        public City(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1}",Id,Name);
        }
    }
}
