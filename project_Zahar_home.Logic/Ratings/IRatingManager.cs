using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Ratings
{
    public interface IRatingManager
    {
        IList<Rating> GetRatings();
        Rating GetDishRating(int dishId);
        IList<Rating> Sort(List<Rating> ratings, int? orderBy);
    }
}
