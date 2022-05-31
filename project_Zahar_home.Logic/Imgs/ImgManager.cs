using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using project_Zahar_home.Storage;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Imgs
{
    public class ImgManager : IImgManager
    {
        private RecipeContext _context;
        public ImgManager(RecipeContext context)
        {
            _context = context;
        }
        public Img GetDishImage(int DishId) => _context.Imgs.FirstOrDefault(r => r.Dish_Id == DishId);
        public IList<Img> GetAll() => _context.Imgs.ToList();
    }
}
