using System.Data.Entity.ModelConfiguration;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    class PortMapping : EntityTypeConfiguration<Port>
    {
        public PortMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
