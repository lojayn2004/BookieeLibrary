using Domain.Contracts;
using Domain.Models.Books;
using Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistance.AppData;
using System.Text.Json;

namespace Presistance
{
    public class DbInitializer(ApplicationDbContext _appContext, RoleManager<IdentityRole> _roleManager) : IDbInitializer
    {
        public async Task InitializeAppAsync()
        {
            try
            {
                if (_appContext.Database.GetPendingMigrations().Any())
                {
                    await _appContext.Database.MigrateAsync();

                }

                if (!_appContext.BookCategories.Any())
                {
                    await SeedBookCategories(@"..\Infrastructure\Presistance\AppData\Seeding\BookCategorySeed.json");
                }


                if (!_appContext.Books.Any())
                {
                    await SeedBooks(@"..\Infrastructure\Presistance\AppData\Seeding\BookSeed.json");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
        }

        public async Task InitializeIdentityAsync()
        {
            string[] roles = { "Admin", "Student" };

            foreach (var role in roles)
            {
                if(! await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

            }
        }

        private async Task SeedBookCategories(string bookCategoriesFileName)
        {
            var bookCategoriesData = File.ReadAllText(bookCategoriesFileName);
            
            var bookCategories = JsonSerializer.Deserialize<List<Category>>(bookCategoriesData);

            if (bookCategories is not null && bookCategories.Any())
            {
                
                await _appContext.AddRangeAsync(bookCategories);
                await _appContext.SaveChangesAsync();

            }

        }

        private async Task SeedBooks(string bookFileName)
        {
            var bookData = File.ReadAllText(bookFileName);
            var options = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };
            var books= JsonSerializer.Deserialize<List<Book>>(bookData, options);

            if (books is not null && books.Any())
            {
                await _appContext.AddRangeAsync(books);
                await _appContext.SaveChangesAsync();

            }

        }



    }
}
