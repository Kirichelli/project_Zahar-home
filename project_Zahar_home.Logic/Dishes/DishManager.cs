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

        public  void changeRating(int id, int rating, string userEmail)
        {
           
            var user =  _context.Users.FirstOrDefault(u => u.Email.Equals(userEmail));
            var rate =  _context.Ratings.FirstOrDefault(r => r.Rating_Id == id);
            int count = 1;
            double value = rating;
            foreach (var item in _context.UserRatings.ToList())
            {
                if (item.Rating_Id == rate.Rating_Id)
                {
                    count++;
                    value += item.Rating_Value;
                }
            }
            rate.Rating_Value = Math.Round(value / count, 1);
            var userRating = new UserRating { Rating_Value = rating, Rating_Id = rate.Rating_Id, User_Id = user.User_Id };
            _context.UserRatings.Add(userRating);
            _context.SaveChanges();
            _context.Cooked.Add(new Storage.Entities.Cooked { UserRating_Id = userRating.UserRating_Id, UserRating = userRating }) ;
            _context.Entry(rate).Property(r => r.Rating_Value).IsModified = true;
            _context.SaveChanges();

        }

        public void Create(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.Ratings.Add(new Rating { Dish_Id = dish.Dish_Id, Rating_Value = 0 });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rating = _context.Ratings.FirstOrDefault(r => r.Dish_Id == id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
            }
            var cooked = _context.Cooked.Where(c => c.UserRating.Rating.Dish_Id == id).ToList();
            if (cooked != null)
            {
                foreach (var item in cooked)
                {
                    _context.Cooked.Remove(item);
                }
            }
            var userRatings = _context.UserRatings.Where(ur => ur.Rating.Dish_Id == id).ToList();
            if (userRatings != null)
            {
                foreach (var item in userRatings)
                {
                    _context.UserRatings.Remove(item);
                }
            }
            var dish = _context.Dishes.FirstOrDefault(u => u.Dish_Id == id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);

            }
            _context.SaveChanges();
        }

        public IList<Dish> GetAll() => _context.Dishes.ToList();

        public Dish getDish(int id) => _context.Dishes.FirstOrDefault(d => d.Dish_Id == id);

        public IList<Dish> nameFilter(string searchString) => _context.Dishes.Where(d => d.Name_Dish.Contains(searchString)).ToList();

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
