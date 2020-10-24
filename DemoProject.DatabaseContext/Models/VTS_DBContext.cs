using Microsoft.EntityFrameworkCore;

namespace DemoProject.DatabaseContext
{
    public partial class VTS_DBContext : DbContext
    {
        public VTS_DBContext()
        {
        }

        public VTS_DBContext(DbContextOptions<VTS_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.use
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("Email address")
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasColumnName("Mobile Number")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Organization)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleNumber)
                    .HasName("PK__Vehicle__ABAD885873899E48");

                entity.Property(e => e.VehicleNumber)
                    .HasMaxLength(10)
                    .IsFixedLength().ValueGeneratedOnAdd();

                entity.Property(e => e.BodyType)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ChassisNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EngineNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LoadCarryingCapacity)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MakeOfVehicle)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturingYear)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ModelNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OrganisationName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Vehicle__UserID__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
