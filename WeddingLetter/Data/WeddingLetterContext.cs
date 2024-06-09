using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WeddingLetter.Models;

namespace WeddingLetter.Data
{
    public class WeddingLetterContext : IdentityDbContext<ApplicationUser>
    {
        public WeddingLetterContext(DbContextOptions<WeddingLetterContext> options) : base(options) 
        {
            
        }
        
        public DbSet<Company> Company { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Venues> Venues { get; set; }
        public DbSet<Payments> Payments { get; set; }

        //When add Startup class then no need to add this method in here
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=WeddingLetter;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
