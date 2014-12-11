using System;
using Port.Model;
using Port.Model.Repository;
namespace Port.App.ClassItemMenu
{
    class PortItem : ItemMenu
    {
        readonly IRepository<Model.ClassModel.Port> _repository = new PortRepository();
        private const string HeadTable = "Id\tFirstName  LastName  HasShip";

        public override void Add()
        {
            var newPort = new Model.ClassModel.Port();
            Console.WriteLine("Input name of port");
            newPort.Name = ValidateInputData.InputName();
            Console.WriteLine("Input id of city");
            newPort.CityId = ValidateInputData.InputId();
            var repositoryCity = new CityRepository();
            if (repositoryCity.SearchById(newPort.CityId) == null)
            {
                Console.WriteLine("City with id={0} doesn't exist");
                return;
            }
            _repository.Create(newPort);
        }

        public override void Remove()
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
                _repository.Remove(id);
                Console.WriteLine("Port have been removed");
            }
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
            else
            {
                Console.WriteLine("Id\tPort\tCityId");
                Console.WriteLine(port.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                Console.WriteLine("Input a new name for the port");
                port.Name = ValidateInputData.InputName();
                Console.WriteLine("Input a new id  of the city");
                port.CityId = ValidateInputData.InputId();
                _repository.Update(port);
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
                Console.WriteLine("Id\tPort\tCityId");
                Console.WriteLine(port.ToString());
            }
        }

        public override void PrintAll()
        {
            Console.WriteLine("Id\tPort\tCityId");
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
