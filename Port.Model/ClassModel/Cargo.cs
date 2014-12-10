using System;

namespace Port.Model.ClassModel
{
    public class Cargo
    {
        public Cargo(){}

        public Cargo(int id, int number, int tripId, int typeId, int weightCargo, int price, int insurancePrice)
        {
            Id = id;
            Number = number;
            TripId = tripId;
            TypeId = typeId;
            WeightCargo = weightCargo;
            Price = price;
            InsurancePrice = insurancePrice;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int TripId { get; set; }
        public int TypeId { get; set; }
        public int WeightCargo { get; set; }
        public double Price { get; set; }
        public double InsurancePrice { get; set; }

        public override string ToString()
        {
            return String.Format("{0:000000}\t{1:########}     {2:000000}     {3:000000}      {4:#######}        {5}         {6}"
                , Id, Number, TypeId, TripId, WeightCargo, Price, InsurancePrice);
        }
    }
}
