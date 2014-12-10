using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port.App.ClassItemMenu
{
    class CaptainItem : ItemMenu
    {
        readonly IRepository<Captain> _repository = new CaptainRepository();
        public override void Add()
        {
            var newCaptain = new Captain();
            Console.WriteLine("Input firstname a captain");
            newCaptain.FirstName = ValidateInputData.InputName();
            Console.Clear();
            Console.WriteLine("Input lastname a captain");
            newCaptain.LastName = ValidateInputData.InputName();
            _repository.Create(newCaptain);
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the captain");
            var id = ValidateInputData.InputId();
            var captain = _repository.SearchById(id);
            if (captain == null)
            {
                Console.WriteLine("Captain with id = {0} doesn't exist", id);
            }
            else
            {
                _repository.Remove(id);
                Console.WriteLine("Captain have been removed");
            }
        }


        public override void Update()
        {
            Console.WriteLine("Input captain id ");
            var id = ValidateInputData.InputId();
            var captain = _repository.SearchById(id);
            if (captain == null)
            {
                Console.WriteLine("Captain with id = {0} doesn't exist", id);
                return;
            }
            else
            {
                Console.WriteLine("Id\tFirstName\tLastName");
                Console.WriteLine(captain.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                Console.WriteLine("Input new firstname captain");
                captain.FirstName = ValidateInputData.InputName();
                Console.WriteLine("Input new lastname captain");
                captain.LastName = ValidateInputData.InputName();
                _repository.Update(captain);
            }

        }

        public override void SearchById()
        {
            Console.WriteLine("Input Captain id ");
            var id = ValidateInputData.InputId();
            var captain = _repository.SearchById(id);
            if (captain == null)
            {
                Console.WriteLine("Captain with id = {0} doesn't exist", id);
            }
            else
            {
                Console.WriteLine("Id\tFirstName\tLastName");
                Console.WriteLine(captain.ToString());
            }
        }

        public override void PrintAll()
        {
            Console.WriteLine("Id\tFirstName\tLastName");
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
