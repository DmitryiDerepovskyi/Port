using System;
using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;

namespace Port.App.ClassItemMenu
{
    class ShipItem : ItemMenu
    {
        readonly IRepository<Ship> _repository = new ShipRepository();
        public override void Add()
        {
            var newShip = new Ship();
            Console.WriteLine("Input id of captain");
            newShip.CaptainId = ValidateInputData.InputId();
            var repositoryCaptain = new CaptainRepository();
            if (repositoryCaptain.SearchById(newShip.CaptainId) == null)
            {
                Console.WriteLine("Captain with id={0} doesn't exist");
                return;
            }
            Console.WriteLine("Input number of Ship");
            newShip.Number = ValidateInputData.InputNumber();
            Console.WriteLine("Input capacity of Ship");
            newShip.Capacity = ValidateInputData.InputNumber();
            Console.WriteLine("Input date of create (yyyy/mm/dd) the Ship");
            newShip.DateCreate = ValidateInputData.InputDate();
            Console.WriteLine("Input max distance the Ship");
            newShip.MaxDistance = ValidateInputData.InputNumber();
            Console.WriteLine("Input team count the Ship");
            newShip.TeamCount = ValidateInputData.InputNumber();
            _repository.Create(newShip);
        }


        public override void Remove()
        {
            Console.WriteLine("Input id of the ship");
            var id = ValidateInputData.InputId();
            var ship = _repository.SearchById(id);
            if (ship == null)
            {
                Console.WriteLine("Ship with id = {0} doesn't exist", id);
            }
            else
            {
                _repository.Remove(id);
                Console.WriteLine("Ship have been removed");
            }
        }

        public override void Update()
        {
            Console.WriteLine("Input id of Ship");
            var id = ValidateInputData.InputId();
            var Ship = _repository.SearchById(id);
            if (Ship == null)
            {
                Console.WriteLine("Ship with id = {0} doesn't exist", id);
                return;
            }
            else
            {
                Console.WriteLine("Id\tCaptainId  Number Capacity DateCreate  MaxDistance TeamCount");
                Console.WriteLine(Ship.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                Console.WriteLine("Input id of captain");
                Ship.CaptainId = ValidateInputData.InputId();
                var repositoryCaptain = new CaptainRepository();
                if (repositoryCaptain.SearchById(Ship.CaptainId) == null)
                {
                    Console.WriteLine("Captain with id={0} doesn't exist");
                    return;
                }
                Console.WriteLine("Input number of Ship");
                Ship.Number = ValidateInputData.InputNumber();
                Console.WriteLine("Input capacity of Ship");
                Ship.Capacity = ValidateInputData.InputNumber();
                Console.WriteLine("Input date of create (yyyy/mm/dd) the Ship");
                Ship.DateCreate = ValidateInputData.InputDate();
                Console.WriteLine("Input max distance the Ship");
                Ship.MaxDistance = ValidateInputData.InputNumber();
                Console.WriteLine("Input team count the Ship");
                Ship.TeamCount = ValidateInputData.InputNumber();
                _repository.Update(Ship);
            }

        }

        public override void SearchById()
        {
            Console.WriteLine("Input id of the Ship");
            var id = ValidateInputData.InputId();
            var Ship = _repository.SearchById(id);
            if (Ship == null)
            {
                Console.WriteLine("Ship with id = {0} doesn't exist", id);
            }
            else
            {
                Console.WriteLine("Id\tCaptainId  Number Capacity DateCreate  MaxDistance TeamCount");
                Console.WriteLine(Ship.ToString());
            }
        }

        public override void PrintAll()
        {
            Console.WriteLine("Id\tCaptainId  Number Capacity DateCreate  MaxDistance TeamCount");
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
