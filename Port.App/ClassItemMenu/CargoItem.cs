using System;
using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;

namespace Port.App.ClassItemMenu
{
    class CargoItem : ItemMenu
    {
        readonly IRepository<Cargo> _repository = new CargoRepository();
        private const string HeadTable = "Id\tNumber  TypeId  TripId  WeightCargo  Price\tInsurancePrice";

        public override void Add()
        {
            var newCargo = new Cargo();
            Console.WriteLine("Input number of cargo");
            newCargo.Number = ValidateInputData.InputNumber();
            Console.WriteLine("Input id of type cargo");
            newCargo.TypeId = ValidateInputData.InputId();
            var repositoryType = new TypeCargoRepository();
            if (repositoryType.SearchById(newCargo.TypeId) == null)
            {
                Console.WriteLine("Type with id={0} doesn't exist");
                return;
            }
            Console.WriteLine("Input id of trip");
            newCargo.TripId = ValidateInputData.InputId();
            var repositoryTrip = new TripRepository();
            if (repositoryTrip.SearchById(newCargo.TripId) == null)
            {
                Console.WriteLine("Trip with id={0} doesn't exist", newCargo.TripId);
                return;
            }
            Console.WriteLine("Input weight of cargo");
            newCargo.WeightCargo = ValidateInputData.InputNumber();
            Console.WriteLine("Input price");
            newCargo.Price = ValidateInputData.InputNumber();
            Console.WriteLine("Input insurance price");
            newCargo.InsurancePrice = ValidateInputData.InputNumber();
            _repository.Create(newCargo);
        }

        public override void Remove()
        {
           Console.WriteLine("Input id of the cargo");
            var id = ValidateInputData.InputId();
            var cargo = _repository.SearchById(id);
            if (cargo == null)
            {
                Console.WriteLine("Cargo with id = {0} doesn't exist", id);
            }
            else
            {
                _repository.Remove(id);
                Console.WriteLine("Cargo have been removed");
            }
        }

        public override void Update()
        {
            Console.WriteLine("Input id of cargo");
            var id = ValidateInputData.InputId();
            var cargo = _repository.SearchById(id);
            if (cargo == null)
            {
                Console.WriteLine("Cargo with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine("Input number of cargo");
            cargo.Number = ValidateInputData.InputNumber();
            Console.WriteLine("Input id of type cargo");
            cargo.TypeId = ValidateInputData.InputId();
            var repositoryType = new TypeCargoRepository();
            if (repositoryType.SearchById(cargo.TypeId) == null)
            {
                Console.WriteLine("Type with id={0} doesn't exist", cargo.TripId);
                return;
            }
            Console.WriteLine("Input id of trip");
            cargo.TripId = ValidateInputData.InputId();
            var repositoryTrip = new TripRepository();
            if (repositoryTrip.SearchById(cargo.TripId) == null)
            {
                Console.WriteLine("Trip with id={0} doesn't exist", cargo.TripId);
                return;
            }
            Console.WriteLine("Input weight of cargo");
            cargo.WeightCargo = ValidateInputData.InputNumber();
            Console.WriteLine("Input price");
            cargo.Price = ValidateInputData.InputNumber();
            Console.WriteLine("Input insurance price");
            cargo.InsurancePrice = ValidateInputData.InputNumber();
            _repository.Update(cargo);
        }


        public override void SearchById()
        {
            Console.WriteLine("Input id of the cargo");
            var id = ValidateInputData.InputId();
            var cargo = _repository.SearchById(id);
            if (cargo == null)
            {
                Console.WriteLine("Cargo with id = {0} doesn't exist", id);
            }
            else
            {
                Console.WriteLine(HeadTable);
                Console.WriteLine(cargo.ToString());
            }
        }

        public override void PrintAll()
        {
            Console.WriteLine(HeadTable);
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
