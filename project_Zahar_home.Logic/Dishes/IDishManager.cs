using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Dishes
{
    public interface IDishManager
    {
        Task<IList<Dish>> GetAll();
        Task Create(Dish dish);
        Task Delete(int id);
        Task<IList<Dish>> nameFilter(string name);
    }
}
