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


        public void Delete(int rating_Id, string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(Email));
            var rate = _context.Ratings.FirstOrDefault(r => r.Rating_Id == rating_Id);
            var cooked = _context.Cooked.FirstOrDefault(c => c.UserRating.Rating_Id == rating_Id && c.UserRating.User_Id == user.User_Id);
            _context.Cooked.Remove(cooked);
            var userRating = _context.UserRatings.FirstOrDefault(ur => ur.Rating_Id == rating_Id && ur.User_Id == user.User_Id);
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
            _context.SaveChanges();
        }

        public IList<Dish> GetAll(string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(Email));
            var selected = _context.UserRatings.Where(c => c.User_Id == user.User_Id).ToList();
            var selectedRatings = new List<Rating>();
            foreach (var item in selected)
            {
                selectedRatings.Add(_context.Ratings.FirstOrDefault(r => r.Rating_Id == item.Rating_Id));
            }
            var dishes = new List<Dish>();
            foreach (var item in selectedRatings)
            {
                dishes.Add(_context.Dishes.FirstOrDefault(d => d.Dish_Id == item.Dish_Id));
            }
            return dishes;
        }
    }
}
