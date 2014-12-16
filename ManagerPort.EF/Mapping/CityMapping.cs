using System.Data.Entity.ModelConfiguration;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    internal class CityMapping : EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
