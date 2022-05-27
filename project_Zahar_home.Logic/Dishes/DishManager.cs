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

        public async void changeRating(int id, int rating, string userEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(userEmail));
            var rate = await _context.Ratings.FirstOrDefaultAsync(r => r.Rating_Id == id);
            foreach(var u in rate.Users)
            {
                if (u.Email.Equals(userEmail))
                {
                    return;
                }
            }
            double value = rate.Rating_Value * rate.Users.Count;
            rate.Users.Add(user);
            rate.Rating_Value = (value + rating)/rate.Users.Count;
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

        public IList<Dish> GetDishesByProperties(IList<Dish> dishes , string? level, int? calloriesMin, int? calloriesMax, int? proteinMin, int? proteinMax, int? carbohydratMin, int? carbohydratMax, int? fatMin, int? fatMax, string? typeName)
        {
            if (!string.IsNullOrEmpty(level))
            {
                dishes = dishes.Where(d => d.Level.Equals(level)).ToList();
            }
            if (calloriesMin != null && calloriesMax != null)
            {
                dishes = dishes.Where(d => d.Callories <= calloriesMax && d.Callories >= calloriesMin).ToList();
            }
            if (proteinMin != null && proteinMax != null)
            {
                dishes = dishes.Where(d => d.Protein <= proteinMax && d.Protein >= proteinMin).ToList();
            }
            if (carbohydratMin != null && carbohydratMax != null)
            {
                dishes = dishes.Where(d => d.Carbohydrat <= carbohydratMax && d.Carbohydrat >= carbohydratMin).ToList();
            }
            if (fatMin != null && fatMax != null)
            {
                dishes = dishes.Where(d => d.Fat <= fatMax && d.Fat >= fatMin).ToList();
            }
            if (!string.IsNullOrEmpty(typeName))
            {
                dishes = dishes.Where(d => d.Type_Of_Kitchen.Type_Name == typeName).ToList();
            }
            
            return dishes;
        }

    }
}
