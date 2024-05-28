using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<CustomerEntity> CustomerEntities { get; set; }
        public DbSet<CustomerServiceEntity> CustomerServiceEntities { get; set; }
        public DbSet<GivingTimeEntity> GivingTimeEntities { get; set; }
        public DbSet<HairstylistEntity> HairstylistEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppointmentEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.ServiceType).HasMaxLength(50).IsRequired();
                entity.Property(x => x.Price).IsRequired();
                entity.Property(x => x.DateAndTimeOfAppointment)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("getdate()")
                      .IsRequired();

                entity.HasOne(x => x.CustomerEntity)
                      .WithOne(c => c.AppointmentEntity)
                      .HasForeignKey<AppointmentEntity>(x => x.CustomerId);
            });

            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.HasKey(x => x.CustomerId);
                entity.Property(x => x.FullName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(100);
                entity.Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired();
                entity.Property(x => x.AvailableTime)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("getdate()");
                entity.Property(x => x.BookedAppointment)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("getdate()");

                entity.HasMany(x => x.CustomerServiceEntity)
                      .WithOne(cse => cse.CustomerEntity);

                entity.HasMany(x => x.GivingTimeEntity)
                      .WithOne(gte => gte.Customer);
            });

            modelBuilder.Entity<CustomerServiceEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.ShortnessOfHair).HasMaxLength(100);
                entity.Property(x => x.HairShaping).HasMaxLength(100);
                entity.Property(x => x.ShavingBeard).HasMaxLength(100);
                entity.Property(x => x.GroomMakeUp).HasMaxLength(100);

                entity.HasOne(x => x.CustomerEntity)
                      .WithMany(c => c.CustomerServiceEntity)
                      .HasForeignKey(x => x.CustomerId);

                entity.HasOne(x => x.HairstylistEntity)
                      .WithMany(h => h.CustomerServiceEntitiy)
                      .HasForeignKey(x => x.HairstylistId);
            });

            modelBuilder.Entity<GivingTimeEntity>(entity =>
            {
                entity.HasKey(x => x.GivingTimeId);

                entity.HasOne(x => x.Customer)
                      .WithMany(c => c.GivingTimeEntity)
                      .HasForeignKey(x => x.CustomerId);

                entity.HasOne(x => x.HairstylistEntity)
                      .WithMany(h => h.GivingTimeEntitiy)
                      .HasForeignKey(x => x.HairstylistId);
            });

            modelBuilder.Entity<HairstylistEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.FullName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.HallName).HasMaxLength(200);
                entity.Property(x => x.Address).HasMaxLength(550).IsRequired();
                entity.Property(x => x.PhoneNumber).HasMaxLength(50);
                entity.Property(x => x.ImageName).HasMaxLength(500);
            });
        }
    }
}

