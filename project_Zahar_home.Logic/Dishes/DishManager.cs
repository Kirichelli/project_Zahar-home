using project_Zahar_home.Storage;

namespace project_Zahar_home.Logic.Dishes
{
    public class DishManager : IDishManager
    {
        private readonly RecipeContext _context;
        public DishManager(RecipeContext context)
        {
            _context = context;
        }

        public async Task changeRating(int id, int rating)
        {
            var rate = await _context.Ratings.FirstOrDefaultAsync(r => r.Rating_Id == id);
            int value = rate.Rating_Value * rate.CountOfUsers;
            rate.CountOfUsers++;
            rate.Rating_Value = (value + rating)/rate.CountOfUsers;
            await _context.SaveChangesAsync();
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

        public async Task<Dish> getDish(int id) => await _context.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == id);

        public async Task<IList<Dish>> nameFilter(string searchString) => await _context.Dishes.Where(d => d.Name_Dish.Contains(searchString)).ToListAsync();

    }
}
