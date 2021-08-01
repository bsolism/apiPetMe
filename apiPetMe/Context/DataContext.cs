using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;

namespace apiPetMe.Context
{
    public class DataContext : DbContext
    {
      
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2NG55CV\SQLEXPRESS ; DataBase=PetMe ; Trusted_Connection=True; ");
        }

    }
}