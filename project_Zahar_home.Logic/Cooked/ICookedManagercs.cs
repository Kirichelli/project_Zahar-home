using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Cooked
{
    public interface ICookedManagercs
    {
        Task Delete(int dishId, string Email);
        IList<Dish> GetAll(string Email);
    }
}
