using project_Zahar_home.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Typies_Of_Dish
{
    public class Type_Of_DishManager : IType_Of_DishManager
    {
        private RecipeContext _context;
        public Type_Of_DishManager(RecipeContext context)
        {
            _context = context;
        }

        public Task<IList<Type_Of_Dish>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
