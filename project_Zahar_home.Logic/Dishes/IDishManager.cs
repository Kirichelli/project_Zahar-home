
namespace project_Zahar_home.Logic.Dishes
{
    public interface IDishManager
    {
        IList<Dish> GetAll();
        void Create(Dish dish);
        void Delete(int id);
        IList<Dish> nameFilter(string name);
        Dish getDish(int id);
        void changeRating(int id, int rating, string userEmail);
        IList<Dish> GetDishesByProperties(IList<Dish> dishes, string level, int? calloriesMin, int? calloriesMax, int? proteinMin, int? proteinMax, int? carbohydratMin, int? carbohydratMax, int? fatMin, int? fatMax, string typeName);
    }
}
