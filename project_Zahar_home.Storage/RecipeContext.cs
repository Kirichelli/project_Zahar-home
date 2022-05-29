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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Type_Of_Kitchen> Type_Of_Kitchens { get; set; }
        public DbSet<Cooked> Cooked { get; set; }



    }
}
