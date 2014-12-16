using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    class CargoItem : ItemMenu
    {
        readonly IRepository<Cargo> _repository = new CargoRepository();
        private const string HeadTable = "Id\tNumber  TypeId  TripId  WeightCargo  Price\tInsurancePrice";

        public override void Add()
        {
            var newCargo = new Cargo();
            try
            {
                InputDataCargo(ref newCargo);
                _repository.Create(newCargo);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the cargo");
            var id = ValidateInputData.InputId();
            var cargo = _repository.SearchById(id);
            if (cargo == null)
            {
                Console.WriteLine("Cargo with id = {0} doesn't exist", id);
                return;
            }
            _repository.Remove(id);
            Console.WriteLine("Cargo have been removed");
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
            try
            {
                InputDataCargo(ref cargo);
                _repository.Update(cargo);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public override void SearchById()
        {
            Console.WriteLine("Input id of the cargo");
            var id = ValidateInputData.InputId();
            var cargo = _repository.SearchById(id);
            if (cargo == null)
            {
                Console.WriteLine("Cargo with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(cargo.ToString());
        }

        public override void PrintAll()
        {
            Console.WriteLine(HeadTable);
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void InputDataCargo(ref Cargo cargo)
        {
            Console.WriteLine("Input number of cargo");
            cargo.Number = ValidateInputData.InputNumber();
            Console.WriteLine("Input id of type cargo");
            cargo.TypeId = ValidateInputData.InputId();
            var repositoryType = new TypeCargoRepository();
            if (repositoryType.SearchById(cargo.TypeId) == null)
                throw new NullReferenceException(String.Format("Type with id={0} doesn't exist", cargo.TypeId));
            Console.WriteLine("Input id of trip");
            cargo.TripId = ValidateInputData.InputId();
            var repositoryTrip = new TripRepository();
            if (repositoryTrip.SearchById(cargo.TripId) == null)
                throw new NullReferenceException(String.Format("Trip with id={0} doesn't exist", cargo.TypeId));
            Console.WriteLine("Input weight of cargo");
            cargo.WeightCargo = ValidateInputData.InputNumber();
            Console.WriteLine("Input price");
            cargo.Price = ValidateInputData.InputNumber();
            Console.WriteLine("Input insurance price");
            cargo.InsurancePrice = ValidateInputData.InputNumber();
        }
    }
}
