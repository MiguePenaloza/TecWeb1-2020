using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Data
{
    public class MusicStoreDbContext : IdentityDbContext
    {
        public DbSet<StoreEntity> Stores { get; set; }
        public DbSet<InstrumentEntity> Instruments { get; set; }

        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StoreEntity>().ToTable("Stores");
            modelBuilder.Entity<StoreEntity>().HasMany(s => s.Instruments).WithOne(i => i.Store);
            modelBuilder.Entity<StoreEntity>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<InstrumentEntity>().ToTable("Instruments");
            modelBuilder.Entity<InstrumentEntity>().HasOne(i => i.Store).WithMany(s => s.Instruments);
            modelBuilder.Entity<InstrumentEntity>().Property(i => i.Id).ValueGeneratedOnAdd();
        }
    }
}
