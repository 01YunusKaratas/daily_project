using emregayrımenkul.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace emregayrımenkul.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet Tanımlamaları
        public DbSet<Advert> Advert { get; set; }
        public DbSet<AdvertDetails> AdvertDetails { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // ❌ `CASCADE` yerine ✅ `RESTRICT` veya `NO ACTION` koyduk!
    modelBuilder.Entity<Advert>()
        .HasOne(a => a.City)
        .WithMany()
        .HasForeignKey(a => a.CityId)
        .OnDelete(DeleteBehavior.Restrict);  // ❌ `CASCADE` değil, ✅ `RESTRICT`!

    modelBuilder.Entity<Advert>()
        .HasOne(a => a.District)
        .WithMany()
        .HasForeignKey(a => a.DistrictId)
        .OnDelete(DeleteBehavior.Restrict);  // ❌ `CASCADE` değil, ✅ `RESTRICT`!

    // ✅ `Advert` silinirse `AdvertDetails` silinsin (Sorun yok!)
    modelBuilder.Entity<AdvertDetails>()
        .HasOne(ad => ad.Advert)
        .WithOne(a => a.AdvertDetails)
        .HasForeignKey<AdvertDetails>(ad => ad.AdvertId)
        .OnDelete(DeleteBehavior.Cascade);  // ✅ `CASCADE` kalsın!

    // ✅ `City` silinirse `District` silinsin (Sorun yok!)
    modelBuilder.Entity<District>()
        .HasOne(d => d.City)
        .WithMany(c => c.Districts)
        .HasForeignKey(d => d.CityId)
        .OnDelete(DeleteBehavior.Cascade);  // ✅ `CASCADE` kalsın!

    // `decimal` alan için `HasColumnType` (NetArea)
    modelBuilder.Entity<AdvertDetails>()
        .Property(a => a.NetArea)
        .HasColumnType("decimal(18, 2)");
}



    }
}
