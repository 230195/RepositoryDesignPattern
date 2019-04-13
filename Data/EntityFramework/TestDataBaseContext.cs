using System;
using Microsoft.EntityFrameworkCore;
using Data.Helper;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.EntityFramework
{
    public partial class TestDataBaseContext : DbContext
    {
        public TestDataBaseContext()
        {
        }

        public TestDataBaseContext(DbContextOptions<TestDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var settings = new DataSettingsManager().LoadSettings();
                var connectionString = Convert.ToString(settings.DataConnectionString);
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ModifiedOn).HasColumnType("time without time zone");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
