using System.Data.Entity.ModelConfiguration;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    class TripMapping : EntityTypeConfiguration<Trip>
    {
        public TripMapping()
        {
            HasKey(t => t.Id);
            Property(t => t.StartDate)
                .IsRequired();
            Property(t => t.EndDate)
                .IsRequired();
        }
    }
}
