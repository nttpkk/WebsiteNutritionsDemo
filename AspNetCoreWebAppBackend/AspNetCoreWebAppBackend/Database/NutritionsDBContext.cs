using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreWebAppBackend.Database
{
    public partial class NutritionsDBContext : DbContext
    {
        public NutritionsDBContext()
        {
        }

        public NutritionsDBContext(DbContextOptions<NutritionsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Desktop\\SQLEXPRESS;Database=NutritionsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK_NutritionIntake");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EventDate)
                    .HasColumnName("eventDate")
                    .HasColumnType("date");

                entity.Property(e => e.FoodAmount).HasColumnName("foodAmount");

                entity.Property(e => e.FoodCarbonhydrate).HasColumnName("foodCarbonhydrate");

                entity.Property(e => e.FoodFat).HasColumnName("foodFat");

                entity.Property(e => e.FoodId).HasColumnName("foodID");

                entity.Property(e => e.FoodProtein).HasColumnName("foodProtein");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Events)
                    .HasForeignKey<Events>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Foods");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Events_Users");
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.Property(e => e.FoodId).HasColumnName("foodID");

                entity.Property(e => e.FoodCarbonhydrate).HasColumnName("foodCarbonhydrate");

                entity.Property(e => e.FoodFat).HasColumnName("foodFat");

                entity.Property(e => e.FoodName)
                    .HasColumnName("foodName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FoodProtein).HasColumnName("foodProtein");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
