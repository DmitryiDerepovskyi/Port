using System;
using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;

namespace Port.App.ClassItemMenu
{
    public class TripItem : ItemMenu
    {
        readonly IRepository<Trip> _repository = new TripRepository();

        public override void Add()
        {
            var newTrip = new Trip();
            Console.WriteLine("Input id of ship");
            newTrip.ShipId = ValidateInputData.InputId();
            var repositoryShip = new ShipRepository();
            if (repositoryShip.SearchById(newTrip.ShipId) == null)
            {
                Console.WriteLine("Ship with id={0} doesn't exist", newTrip.ShipId);
                return;
            }
            Console.WriteLine("Input id of port from start trip");
            newTrip.PortFromId = ValidateInputData.InputId();
            var repositoryPort = new PortRepository();
            if (repositoryPort.SearchById(newTrip.PortFromId) == null)
            {
                Console.WriteLine("Port with id={0} doesn't exist");
                return;
            }
            Console.WriteLine("Input id of port to end trip");
            newTrip.PortToId = ValidateInputData.InputId();
            if (repositoryPort.SearchById(newTrip.PortToId) == null)
            {
                Console.WriteLine("Port with id={0} doesn't exist");
                return;
            }
            if (newTrip.PortFromId == newTrip.PortToId)
            {
                Console.WriteLine("Port from can't equal port to");
                return;
            }
            Console.WriteLine("Input date of start trip (yyyy/mm/dd)");
            newTrip.StartDate = ValidateInputData.InputDate();
            Console.WriteLine("Input date of end trip (yyyy/mm/dd)");
            newTrip.EndDate = ValidateInputData.InputDate();
            if (DateTime.Parse(newTrip.EndDate) < DateTime.Parse(newTrip.StartDate))
            {
                Console.WriteLine("End date can't be earlier than the start date");
                return;
            }
            _repository.Create(newTrip);
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
            else
            {
                Console.WriteLine("Id\tShipId   CaptainId   PortFromId   PortToId   StartDate   EndDate");
                Console.WriteLine(trip.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                Console.WriteLine("Input id of ship");
                trip.ShipId = ValidateInputData.InputId();
                var repositoryShip = new ShipRepository();
                if (repositoryShip.SearchById(trip.ShipId) == null)
                {
                    Console.WriteLine("Ship with id={0} doesn't exist");
                    return;
                }
                Console.WriteLine("Input id of port from start trip");
                trip.PortFromId = ValidateInputData.InputId();
                var repositoryPort = new PortRepository();
                if (repositoryPort.SearchById(trip.PortFromId) == null)
                {
                    Console.WriteLine("Port with id={0} doesn't exist");
                    return;
                }
                Console.WriteLine("Input id of port to end trip");
                trip.PortToId = ValidateInputData.InputId();
                if (repositoryPort.SearchById(trip.PortToId) == null)
                {
                    Console.WriteLine("Port with id={0} doesn't exist");
                    return;
                }
                if (trip.PortFromId == trip.PortToId)
                {
                    Console.WriteLine("Port from can't equal port to");
                    return;
                }
                Console.WriteLine("Input date of start trip (yyyy/mm/dd)");
                trip.StartDate = ValidateInputData.InputDate();
                Console.WriteLine("Input date of end trip (yyyy/mm/dd)");
                trip.EndDate = ValidateInputData.InputDate();
                if (DateTime.Parse(trip.EndDate) < DateTime.Parse(trip.StartDate))
                {
                    Console.WriteLine("End date can't be earlier than the start date");
                    return;
                }
                _repository.Update(trip);
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
                Console.WriteLine("Id\tShipId   CaptainId   PortFromId   PortToId   StartDate   EndDate");
                Console.WriteLine(trip.ToString());
            }
        }

        public override void PrintAll()
        {
            Console.WriteLine("Id\tShipId   CaptainId   PortFromId   PortToId   StartDate   EndDate");
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
