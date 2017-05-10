using Microsoft.EntityFrameworkCore;
using EfSamurai.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace EfSamurai.Data
{
    public class SamuraiContext : DbContext

    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattleEvent> BattleEvents { get; set; }
        public DbSet<BattleLog> BattleLogs { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = EfSamurai; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(samuraiBattle => new { samuraiBattle.SamuraiId, samuraiBattle.BattleId });
        }
    }
}
