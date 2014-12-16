using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    class CityItem : ItemMenu
    {
        readonly IRepository<City> _repository = new CityRepository();
        private const string HeadTable = "Id\tCity";

        public override void Add()
        {
            var newCity = new City();
            InputDataCity(ref newCity);
            _repository.Create(newCity);
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the city");
            var id = ValidateInputData.InputId();
            var port = _repository.SearchById(id);
            if (port == null)
            {
                Console.WriteLine("City with id = {0} doesn't exist", id);
                return;
            }
            _repository.Remove(id);
            Console.WriteLine("City have been removed");
        }

        public override void Update()
        {
            Console.WriteLine("Input city id ");
            var id = ValidateInputData.InputId();
            var city = _repository.SearchById(id);
            if (city == null)
            {
                Console.WriteLine("City with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(city.ToString());
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                InputDataCity(ref city);
                _repository.Update(city);
            }
        }

        public override void SearchById()
        {
            Console.WriteLine("Input city id ");
            var id = ValidateInputData.InputId();
            var city = _repository.SearchById(id);
            if (city == null)
            {
                Console.WriteLine("City with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(city.ToString());
        }

        public override void PrintAll()
        {
            Console.WriteLine(HeadTable);
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void InputDataCity(ref City city)
        {
            Console.WriteLine("Input name city");
            city.Name = ValidateInputData.InputName();
        }
    }
}
