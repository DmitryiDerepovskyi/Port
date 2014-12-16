using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    public class TripItem : ItemMenu
    {
        readonly IRepository<Trip> _repository = new TripRepository();
        private const string HeadTable = "Id\tShipId   CaptainId   PortFromId   PortToId   StartDate   EndDate";
        public override void Add()
        {
            try
            {
                var newTrip = new Trip();
                InputDataTrip(ref newTrip);
                _repository.Create(newTrip);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the trip");
            var id = ValidateInputData.InputId();
            var trip = _repository.SearchById(id);
            if (trip == null)
            {
                Console.WriteLine("Trip with id = {0} doesn't exist", id);
            }
            else
            {
                _repository.Remove(id);
                Console.WriteLine("Trip have been removed");
            }
        }

        public override void Update()
        {
            Console.WriteLine("Input id of trip");
            var id = ValidateInputData.InputId();
            var trip = _repository.SearchById(id);
            if (trip == null)
            {
                Console.WriteLine("Trip with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(trip.ToString());
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                try
                {
                    var newTrip = new Trip();
                    InputDataTrip(ref newTrip);
                    _repository.Update(trip);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public override void SearchById()
        {
            Console.WriteLine("Input id of the Trip");
            var id = ValidateInputData.InputId();
            var trip = _repository.SearchById(id);
            if (trip == null)
            {
                Console.WriteLine("Trip with id = {0} doesn't exist", id);
            }
            else
            {
                Console.WriteLine(HeadTable);
                Console.WriteLine(trip.ToString());
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

        private void InputDataTrip(ref Trip trip)
        {
            Console.WriteLine("Input id of ship");
            var shipId = ValidateInputData.InputId();
            var repositoryShip = new ShipRepository();
            var ship = repositoryShip.SearchById(shipId);
            if (ship == null)
                throw new NullReferenceException(String.Format("Ship with id={0} doesn't exist", shipId));
            if (ship.CaptainId == null)
                throw new NullReferenceException(String.Format("Ship with id={0} hasn't captain", shipId));
            trip.CaptainId = (int)ship.CaptainId;
            trip.ShipId = shipId;
            Console.WriteLine("Input id of port from start trip");
            trip.PortFromId = ValidateInputData.InputId();
            var repositoryPort = new PortRepository();
            if (repositoryPort.SearchById(trip.PortFromId) == null)
                throw new NullReferenceException(String.Format("Port with id={0} doesn't exist", trip.PortFromId));
            Console.WriteLine("Input id of port to end trip");
            trip.PortToId = ValidateInputData.InputId();
            if (repositoryPort.SearchById(trip.PortToId) == null)
                throw new NullReferenceException(String.Format("Port with id={0} doesn't exist", trip.PortToId));
            if (trip.PortFromId == trip.PortToId)
                throw new ArgumentException(String.Format("Port from can't equal port to"));
            Console.WriteLine("Input date of start trip (yyyy/mm/dd)");
            trip.StartDate = ValidateInputData.InputDate();
            Console.WriteLine("Input date of end trip (yyyy/mm/dd)");
            trip.EndDate = ValidateInputData.InputDate();
            if (trip.EndDate < trip.StartDate)
                throw new ArgumentException(String.Format("End date can't be earlier than the start date"));
        }
    }
}
