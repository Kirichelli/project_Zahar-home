using project_Zahar_home.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Cooked
{
    public class CookedManagercs:ICookedManagercs
    {
        private readonly RecipeContext _context;
        public CookedManagercs(RecipeContext context)
        {
            _context = context;
        }

        public async void Add(int dishId, string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == dishId);
            foreach (var item in user.Cooked.cookedDishes)
            {
                if (item.Dish_Id == dishId) return;
            }
            user.Cooked.cookedDishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int dishId, string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == dishId);
            foreach (var item in user.Cooked.cookedDishes)
            {
                if (item.Dish_Id == dish.Dish_Id) user.Cooked.cookedDishes.Remove(dish);
            }
            await _context.SaveChangesAsync();
        }

        public IList<Dish> GetAll(string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            return user.Cooked.cookedDishes.ToList();
        }
    }
}
