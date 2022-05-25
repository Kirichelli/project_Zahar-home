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

        public async Task<Rating> GetDishRating(int RatingId) => await _context.Ratings.FirstOrDefaultAsync(r => r.Rating_Id == RatingId);

        public async Task<IList<Rating>> GetRatings() => await _context.Ratings.ToListAsync();
    }
}
