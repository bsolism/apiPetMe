using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;

namespace apiPetMe.Context
{
    public class DataContext : DbContext
    {
      
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5105.site4now.net;Initial Catalog=db_a782b2_petme;User Id=db_a782b2_petme_admin;Password=petme.2021");
        }

    }
}