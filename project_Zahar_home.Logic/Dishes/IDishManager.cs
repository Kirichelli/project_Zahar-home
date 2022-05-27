
namespace project_Zahar_home.Logic.Dishes
{
    public interface IDishManager
    {
        Task<IList<Dish>> GetAll();
        Task Create(Dish dish);
        Task Delete(int id);
        Task<IList<Dish>> nameFilter(string name);
        Task<Dish> getDish(int id);
        void changeRating(int id, int rating, string userEmail);
        IList<Dish> GetDishesByProperties(IList<Dish> dishes, string level, int? calloriesMin, int? calloriesMax, int? proteinMin, int? proteinMax, int? carbohydratMin, int? carbohydratMax, int? fatMin, int? fatMax, string typeName);
    }
}
