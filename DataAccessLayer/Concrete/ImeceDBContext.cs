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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RTCY;Database=Imece;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
