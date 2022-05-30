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


        public async Task Delete(int rating_Id, string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(Email));
            var rate = await _context.Ratings.FirstOrDefaultAsync(r => r.Rating_Id == rating_Id);
            var cooked = await _context.Cooked.FirstOrDefaultAsync(c => c.UserRating.Rating_Id == rating_Id && c.UserRating.User_Id == user.User_Id);
            _context.Cooked.Remove(cooked);
            var userRating = await _context.UserRatings.FirstOrDefaultAsync(ur => ur.Rating_Id == rating_Id && ur.User_Id == user.User_Id);
            _context.UserRatings.Remove(userRating);
            int count = 0;
            double value = 0;
            foreach (var item in _context.UserRatings.ToList())
            {
                if (item.Rating_Id == rate.Rating_Id)
                {
                    count++;
                    value += item.Rating_Value;
                }
            }
            rate.Rating_Value = value / count;
            await _context.SaveChangesAsync();
        }

        public IList<Dish> GetAll(string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            var selected = _context.Cooked.Where(c => c.UserRating.User_Id == user.User_Id).ToList();
            var dishes = new List<Dish>();
            foreach(var item in selected)
            {
                dishes.Add(item.UserRating.Rating.Dish);
            }
            return dishes;
        }
    }
}
