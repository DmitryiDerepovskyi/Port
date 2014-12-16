using System.Data.Entity;
using System.Reflection;
using ManagerPort.Model.ClassModel;

namespace ManagerPort.EF
{
    public class ManagerPortContext : DbContext
    {
        public ManagerPortContext()
            : base("ManagerPortConnectionString") 
        {
        }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<TypeCargo> TypesCargo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            //one-to-many 
            modelBuilder.Entity<Cargo>().HasRequired<TypeCargo>(c => c.Type)
            .WithMany(tc => tc.Cargos).HasForeignKey(c => c.TypeId);
            modelBuilder.Entity<Cargo>().HasRequired<Trip>(c => c.Trip)
           .WithMany(t => t.Cargos).HasForeignKey(c => c.TripId);

            modelBuilder.Entity<Port>().HasRequired<City>(p => p.City)
           .WithMany(c => c.Ports).HasForeignKey(p => p.CityId)
           .WillCascadeOnDelete(true);

            modelBuilder.Entity<Port>().HasMany(t => t.Trips)
                .WithRequired(p => p.PortTo)
                .HasForeignKey(t => t.PortToId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Port>().HasMany(t => t.Trips)
                .WithRequired(p => p.PortFrom)
                .HasForeignKey(t => t.PortFromId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>().HasRequired<Captain>(t => t.Captain)
           .WithMany(c => c.Trips).HasForeignKey(t => t.CaptainId);

            // Map one-to-zero or one relationship 
            modelBuilder.Entity<Ship>()
                 .HasOptional(s => s.Captain)
                .WithMany(c => c.Ships)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
