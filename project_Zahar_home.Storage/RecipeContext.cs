using Microsoft.EntityFrameworkCore;
using project_Zahar_home.Storage.Entities;
namespace project_Zahar_home.Storage
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Rating_user> Rating_Users { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

    }
}
