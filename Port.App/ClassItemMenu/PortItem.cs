using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    class PortItem : ItemMenu
    {
        readonly IRepository<Port> _repository = new PortRepository();
        private const string HeadTable = "Id\tName\tCityId";

        public override void Add()
        {
            var newPort = new Port();
            try
            {
                InputDataPort(ref newPort);
                _repository.Create(newPort);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the port");
            var id = ValidateInputData.InputId();
            var port = _repository.SearchById(id);
            if (port == null)
            {
                Console.WriteLine("Port with id = {0} doesn't exist", id);
                return;
            }
            _repository.Remove(id);
            Console.WriteLine("Port have been removed");
        }

        public override void Update()
        {
            Console.WriteLine("Input id of port");
            var id = ValidateInputData.InputId();
            var port = _repository.SearchById(id);
            if (port == null)
            {
                Console.WriteLine("Port with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(port.ToString());
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                try
                {
                    InputDataPort(ref port);
                    _repository.Create(port);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public override void SearchById()
        {
            Console.WriteLine("Input id of the port");
            var id = ValidateInputData.InputId();
            var port = _repository.SearchById(id);
            if (port == null)
            {
                Console.WriteLine("Port with id = {0} doesn't exist", id);
            }
            else
            {
                Console.WriteLine(HeadTable);
                Console.WriteLine(port.ToString());
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

        private void InputDataPort(ref Port port)
        {
            Console.WriteLine("Input name of port");
            port.Name = ValidateInputData.InputName();
            Console.WriteLine("Input id of city");
            port.CityId = ValidateInputData.InputId();
            var repositoryCity = new CityRepository();
            if (repositoryCity.SearchById(port.CityId) == null)
                throw new NullReferenceException(string.Format("City with id={0} doesn't exist", port.CityId));
        }
    }
}
