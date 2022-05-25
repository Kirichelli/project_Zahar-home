using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Ratings
{
    public interface IRatingManager
    {
        Task<IList<Rating>> GetRatings();
        Task<Rating> GetDishRating(int RatingId);
    }
}
