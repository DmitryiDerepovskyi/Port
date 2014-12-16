using System;
using System.Collections.Generic;

namespace ManagerPort.Model.ClassModel
{
    public class Cargo
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int TripId { get; set; }
        public int TypeId { get; set; }
        public int WeightCargo { get; set; }
        public double Price { get; set; }
        public double InsurancePrice { get; set; }

        public virtual Trip Trip { get; set; }
        public virtual TypeCargo Type { get; set; }

        public override string ToString()
        {
            return String.Format("{0,6:000000}  {1,6}  {2,6:000000}  {3,6:000000}  {4,11}  {5,5}\t{6,14}"
                , Id, Number, TypeId, TripId, WeightCargo, Price, InsurancePrice);
        }
    }
}
