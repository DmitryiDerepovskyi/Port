using System;

namespace Port.Model.ClassModel
{
    public class Captain
    {
        public Captain(){}

        public Captain(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1}\t\t{2}",Id,FirstName,LastName);
        }
    }
}
