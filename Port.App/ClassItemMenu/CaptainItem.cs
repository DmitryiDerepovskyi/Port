using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    class CaptainItem : ItemMenu
    {
        readonly IRepository<Captain> _repository = new CaptainRepository();
        private const string HeadTable = "Id\tFirstName  LastName  ShipId";

        public override void Add()
        {
            var newCaptain = new Captain();
           InputDataCaptain(ref newCaptain);
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
            Console.WriteLine(HeadTable);
            Console.WriteLine(captain.ToString());
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) == 'y')
            {
                InputDataCaptain(ref captain);
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
                Console.WriteLine(HeadTable);
                Console.WriteLine(captain.ToString());
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

        private void InputDataCaptain(ref Captain captain)
        {
            Console.WriteLine("Input firstname a captain");
            captain.FirstName = ValidateInputData.InputName();
            Console.WriteLine("Input lastname a captain");
            captain.LastName = ValidateInputData.InputName();
        }
    }
}
