using System;
using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;

namespace Port.App.ClassItemMenu
{
    class ShipItem : ItemMenu
    {
        readonly IRepository<Ship> _repository = new ShipRepository();
        private const string HeadTable = "Id\tCaptainId  Number  Capacity  DateCreate  MaxDistance TeamCount";

        public override void Add()
        {
            var newShip = new Ship();
            Console.WriteLine("Input id of captain");
            var captainId = ValidateInputData.InputId();
            var repositoryCaptain = new CaptainRepository();
            var captain = repositoryCaptain.SearchById(captainId);
            if ( captain == null)
            {
                Console.WriteLine("Captain with id={0} doesn't exist", captainId);
                return;
            }
            if(captain.HasShip)
            {
                Console.WriteLine("Captain with id={0} already has ship", captainId);
                return;
            }
            newShip.CaptainId = captainId;
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
            var ship = _repository.SearchById(id);
            if (ship == null)
            {
                Console.WriteLine("Ship with id = {0} doesn't exist", id);
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(ship.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                Console.WriteLine("Input id of captain");
                var captainId = ValidateInputData.InputId();
                var repositoryCaptain = new CaptainRepository();
                var captain = repositoryCaptain.SearchById(captainId);
                if (captain == null)
                {
                    Console.WriteLine("Captain with id={0} doesn't exist", captainId);
                    return;
                }
                if (captain.HasShip)
                {
                    Console.WriteLine("Captain with id={0} already has ship", captainId);
                    return;
                }
                ship.CaptainId = captainId;
                Console.WriteLine("Input number of Ship");
                ship.Number = ValidateInputData.InputNumber();
                Console.WriteLine("Input capacity of Ship");
                ship.Capacity = ValidateInputData.InputNumber();
                Console.WriteLine("Input date of create (yyyy/mm/dd) the Ship");
                ship.DateCreate = ValidateInputData.InputDate();
                Console.WriteLine("Input max distance the Ship");
                ship.MaxDistance = ValidateInputData.InputNumber();
                Console.WriteLine("Input team count the Ship");
                ship.TeamCount = ValidateInputData.InputNumber();
                _repository.Update(ship);
            }

        }

        public override void SearchById()
        {
            Console.WriteLine("Input id of the Ship");
            var id = ValidateInputData.InputId();
            var ship = _repository.SearchById(id);
            if (ship == null)
            {
                Console.WriteLine("Ship with id = {0} doesn't exist", id);
            }
            else
            {
                Console.WriteLine(HeadTable);
                Console.WriteLine(ship.ToString());
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
