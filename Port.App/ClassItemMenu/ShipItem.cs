using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    class ShipItem : ItemMenu
    {
        readonly IRepository<Ship> _repository = new ShipRepository();
        private const string HeadTable = "Id\tCaptainId  Number  Capacity  DateCreate  MaxDistance TeamCount";

        public override void Add()
        {
            var newShip = new Ship();
            try
            {
                InputDataShip(ref newShip);
                _repository.Create(newShip);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the ship");
            var id = ValidateInputData.InputId();
            var ship = _repository.SearchById(id);
            if (ship == null)
            {
                Console.WriteLine("Ship with id = {0} doesn't exist", id);
                return;
            }
            _repository.Remove(id);
            Console.WriteLine("Ship have been removed");
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
            Console.WriteLine(ship.ToString());
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                try
                {
                    InputDataShip(ref ship);
                    _repository.Update(ship);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
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
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(ship.ToString());
        }

        public override void PrintAll()
        {
            Console.WriteLine(HeadTable);
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void InputDataShip(ref Ship ship)
        {
            Console.WriteLine("Input id of captain");
            var captainId = ValidateInputData.InputId();
            var repositoryCaptain = new CaptainRepository();
            var captain = repositoryCaptain.SearchById(captainId);
            if (captain == null)
                throw new NullReferenceException(string.Format("Captain with id={0} doesn't exist", captainId));
            ship.CaptainId = captain.Id;
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
        }
    }
}
