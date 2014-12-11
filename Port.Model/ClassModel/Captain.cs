using System;

namespace Port.Model.ClassModel
{
    public class Captain
    {
        public Captain(){}

        public Captain(int id, string firstName, string lastName, bool hasShip)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HasShip = hasShip;
        }

        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasShip { get; private set; }

        public override string ToString()
        {
            return String.Format("{0:000000}  {1, 9}  {2,8}  {3,7}",Id,FirstName,LastName,HasShip);
        }
    }
}
