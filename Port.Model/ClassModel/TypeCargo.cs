namespace Port.Model.ClassModel
{
    public class TypeCargo
    {
        
        public TypeCargo(){}

        public TypeCargo(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public override string ToString()
        {
            return string.Format("{0:000000} {1}", Id, TypeName);
        }
    }
}
