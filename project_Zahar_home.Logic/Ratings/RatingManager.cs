using project_Zahar_home.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Ratings
{
    public class RatingManager : IRatingManager
    {
        private RecipeContext _context;
        public RatingManager(RecipeContext context)
        {
            _context = context;
        }

        public Rating GetDishRating(int dishId) => _context.Ratings.FirstOrDefault(r => r.Dish_Id == dishId);

        public IList<Rating> GetRatings() => _context.Ratings.ToList();

        public IList<Rating> Sort(List<Rating> ratings, int? orderBy)
        {
            if (orderBy != null)
            {
                ratings.Sort((a, b) => a.Rating_Value.CompareTo(b.Rating_Value));
                if (orderBy == 0)
                {
                    ratings.Reverse();
                }
            }
            return ratings;
        }
    }
}
