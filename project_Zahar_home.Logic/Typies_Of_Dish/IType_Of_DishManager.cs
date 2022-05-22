using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Typies_Of_Dish
{
    public interface IType_Of_DishManager
    {
        Task<IList<Type_Of_Kitchen>> GetAll();
    }
}
