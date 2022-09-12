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
            //optionsBuilder.UseSqlServer(@"");
            //optionsBuilder.UseSqlServer(@"");
            optionsBuilder.UseSqlServer(@"");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestAdoptionMapping());
            modelBuilder.ApplyConfiguration(new DonationMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
