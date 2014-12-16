using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ManagerPort.Model.ClassModel
{
    public class TypeCargo
    {
        public TypeCargo()
        {
            Cargos = new Collection<Cargo>();
        }
        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }

        public override string ToString()
        {
            return string.Format("{0:000000} {1}", Id, TypeName);
        }
    }
}
