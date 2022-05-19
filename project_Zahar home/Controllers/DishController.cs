using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Storage.Entities;

namespace project_Zahar_home.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishManager _manager;

        public DishController(IDishManager manager)
        {
            _manager = manager; 
        }

        
    }
}
