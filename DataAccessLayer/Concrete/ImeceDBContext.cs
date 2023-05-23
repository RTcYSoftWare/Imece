using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ImeceDBContext : DbContext
    {
        public ImeceDBContext()
        {

        }

        public ImeceDBContext(DbContextOptions<ImeceDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Plantation> Plantations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<GrowingArea> GrowingAreas { get; set; }
        public DbSet<SoilType> SoilTypes { get; set; }
        public DbSet<IrrigationType> IrrigationTypes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=RTCY;Database=Imece;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("data source=185.8.128.26; initial catalog=rtcysof1_Imece; persist security info=True; user id=rtcysof1_rtcy; password=dZ7w@55e2;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Plantation>().ToTable("Plantations");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductType>().ToTable("ProductTypes");
            modelBuilder.Entity<GrowingArea>().ToTable("GrowingAreas");
            modelBuilder.Entity<SoilType>().ToTable("SoilTypes");
            modelBuilder.Entity<IrrigationType>().ToTable("IrrigationTypes");
        }
    }
}
