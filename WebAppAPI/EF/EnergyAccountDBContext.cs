using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAppAPI.EF
{
    public partial class EnergyAccountDBContext : DbContext
    {
        public EnergyAccountDBContext()
        {
        }

        public EnergyAccountDBContext(DbContextOptions<EnergyAccountDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MeterReading> MeterReadings { get; set; }
        public virtual DbSet<TestAccount> TestAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=EnergyAccountDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MeterReading>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Meter_Reading");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MeterReadValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MeterReadingDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test_Accounts");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
