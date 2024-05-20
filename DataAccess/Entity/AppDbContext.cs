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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AppointmentEntity>(entity =>
        //    {
        //        entity.HasKey(x => x.Id);
        //        entity.Property(x => x.);
        //    });
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<CustomerEntity> CustomerEntities { get; set; }
        public DbSet<CustomerServiceEntity> CustomerServiceEntities { get; set; }
        public DbSet<GivingTimeEntity> GivingTimeEntities { get; set; }
        public DbSet<HairstylistEntity> HairstylistEntities { get; set; }
    }
}
