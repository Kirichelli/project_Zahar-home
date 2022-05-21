using Microsoft.EntityFrameworkCore;
using project_Zahar_home.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Dishes
{
    public class DishManager : IDishManager
    {
        private readonly RecipeContext _context;
        public DishManager(RecipeContext context)
        {
            _context = context;
        }
    
        public async Task Create(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var dish = _context.Dishes.FirstOrDefault(d => d.Dish_Id == id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Dish>> GetAll() => await _context.Dishes.ToListAsync();

        public async Task<IList<Dish>> nameFilter(string searchString) => await _context.Dishes.Where(d => d.Name_Dish.Contains(searchString)).ToListAsync();
    }
}
