
using Microsoft.EntityFrameworkCore;
using Presistance.AppData.Configurations;
using Domain.Models.Books;
using System.Reflection;
using Domain.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Presistance.AppData
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> BookCategories { get; set; }

        
    }
}
