using System.Data.Entity.ModelConfiguration;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF.Mapping
{
    class CaptainMapping : EntityTypeConfiguration<Captain>
    {
        public CaptainMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.LastName)
              .IsRequired()
              .HasMaxLength(50);
            Property(c => c.LastName)
              .IsRequired()
              .HasMaxLength(50);

        }
    }
}
