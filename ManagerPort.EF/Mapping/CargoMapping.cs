using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    class CargoMapping : EntityTypeConfiguration<Cargo>
    {
        public CargoMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Number)
                .IsRequired();
            Property(c => c.WeightCargo)
                .IsRequired();
            Property(c => c.Price)
                .IsRequired();
            Property(c => c.InsurancePrice)
                .IsRequired();
        }
    }
}
