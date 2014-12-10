using System;
using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;

namespace Port.App.ClassItemMenu
{
    class CityItem : ItemMenu
    {
        readonly IRepository<City> _repository = new CityRepository();
        public override void Add()
        {
            var newCity = new City();
            Console.WriteLine("Input name city");
            newCity.Name = ValidateInputData.InputName();
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
            }
            else
            {
                _repository.Remove(id);
                Console.WriteLine("City have been removed");
            }
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
            else
            {
                Console.WriteLine("Id\tCity");
                Console.WriteLine(city.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                Console.WriteLine("Input new name city");
                city.Name = ValidateInputData.InputName();
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
            }
            else
            {
                Console.WriteLine("Id\tCity");
                Console.WriteLine(city.ToString());
            }
        }

        public override void PrintAll()
        {
            Console.WriteLine("Id\tCity");
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
