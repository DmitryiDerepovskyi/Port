using System.Data.Entity.ModelConfiguration;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    class ShipMapping : EntityTypeConfiguration<Ship>
    {
        public ShipMapping()
        {
            HasKey(s => s.Id);
            Property(s => s.Number)
                .IsRequired();
            Property(s => s.MaxDistance)
              .IsRequired();
            Property(s => s.TeamCount)
              .IsRequired();
            Property(s => s.Capacity)
              .IsRequired();
            Property(s => s.DateCreate)
              .IsRequired();
        }
    }
}
