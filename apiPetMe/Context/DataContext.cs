using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace apiPetMe.Context
{
    public class DataContext : DbContext
    {
      
        public DbSet<User> Users { get; set; }
        public DbSet<ProfileHouse> ProfileHouses { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetPhotos> PetPhotos { get; set; }
        public DbSet<RequestAdoption> RequestAdoptions { get; set; }
        public DbSet<Donation> Donations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=petme.database.windows.net;Initial Catalog=PetMe;User Id=petme;Password=app.2021");
            optionsBuilder.UseSqlServer(@"Data Source=sql5108.site4now.net;Initial Catalog=db_a7deb2_petmedb;User Id=db_a7deb2_petmedb_admin;Password=petme.2021");
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-16IK7DK\SQLEXPRESS;Initial Catalog=PetMeDb;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestAdoptionMapping());
            modelBuilder.ApplyConfiguration(new DonationMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}