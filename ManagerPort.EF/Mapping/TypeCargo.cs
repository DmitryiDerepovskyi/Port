using System.Data.Entity.ModelConfiguration;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    class TypeCargoMapping : EntityTypeConfiguration<TypeCargo>
    {
        public TypeCargoMapping()
        {
            HasKey(tc => tc.Id);
            Property(tc => tc.TypeName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
