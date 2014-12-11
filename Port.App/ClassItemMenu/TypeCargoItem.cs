using System;
using Port.Model;
using Port.Model.ClassModel;
using Port.Model.Repository;

namespace Port.App.ClassItemMenu
{
    class TypeCargoItem : ItemMenu
    {
        readonly IRepository<TypeCargo> _repository = new TypeCargoRepository();
        private const string HeadTable = "Id\tType";

        public override void Add()
        {
            var newTypeCargo = new TypeCargo();
            Console.WriteLine("Input type cargo");
            newTypeCargo.TypeName = ValidateInputData.InputName();
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
            }
            else
            {
                _repository.Remove(id);
                Console.WriteLine("Type have been removed");
            }
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
            else
            {
                Console.WriteLine(HeadTable);
                Console.WriteLine(typeCargo.ToString());
            }
            Console.WriteLine("Update this record?(y)");
            var choose = Console.ReadKey(true).KeyChar;
            if (Char.ToLower(choose) != 'y') return;
            Console.WriteLine("Input new name type");
            typeCargo.TypeName = ValidateInputData.InputName();
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
            }
            else
            {
                Console.WriteLine(HeadTable);
                Console.WriteLine(typeCargo.ToString());
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
    }
}
