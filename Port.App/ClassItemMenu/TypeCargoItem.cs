using System;
using ManagerPort.Model.ClassModel;
using ManagerPort.RepositoryDb;
using ManagerPort.RepositoryDb.Repository;
using ManagerPort.SupportClass;

namespace ManagerPort.App.ClassItemMenu
{
    class TypeCargoItem : ItemMenu
    {
        readonly IRepository<TypeCargo> _repository = new TypeCargoRepository();
        private const string HeadTable = "Id\tType";

        public override void Add()
        {
            var newTypeCargo = new TypeCargo();
            InputDataTypesCargo(ref newTypeCargo);
            _repository.Create(newTypeCargo);
        }

        public override void Remove()
        {
            Console.WriteLine("Input id of the type");
            var id = ValidateInputData.InputId();
            var type = _repository.SearchById(id);
            if (type == null)
            {
                Console.WriteLine("Type with id = {0} doesn't exist", id);
                return;
            }
            _repository.Remove(id);
            Console.WriteLine("Type have been removed");
        }


        public override void Update()
        {
            Console.WriteLine("Input type id ");
            var id = ValidateInputData.InputId();
            var typeCargo = _repository.SearchById(id);
            if (typeCargo == null)
            {
                Console.WriteLine("Type with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(typeCargo.ToString());
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) != 'y') return;
            InputDataTypesCargo(ref typeCargo);
            _repository.Update(typeCargo);
        }

        public override void SearchById()
        {
            Console.WriteLine("Input type id ");
            var id = ValidateInputData.InputId();
            var typeCargo = _repository.SearchById(id);
            if (typeCargo == null)
            {
                Console.WriteLine("Type with id = {0} doesn't exist", id);
                return;
            }
            Console.WriteLine(HeadTable);
            Console.WriteLine(typeCargo.ToString());
        }

        public override void PrintAll()
        {
            Console.WriteLine(HeadTable);
            foreach (var item in _repository.GetItemsList())
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void InputDataTypesCargo(ref TypeCargo typeCargo)
        {
            Console.WriteLine("Input type cargo");
            typeCargo.TypeName = ValidateInputData.InputName();
        }
    }
}
