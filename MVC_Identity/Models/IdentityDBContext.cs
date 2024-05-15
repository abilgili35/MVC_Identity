using Microsoft.EntityFrameworkCore;

namespace MVC_Identity.Models
{
    public class IdentityDBContext:DbContext
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server=ABILGILI\\SQLEXPRESS;database=Identity;Integrated Security=SSPI;TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(new List<AppUser>
            {
                new AppUser
                {
                    Id = 1,
                    UserName = "Test",
                    Password = "Test",
                    Email = "test@gmail.com",
                }
            });
        }
    }
}
