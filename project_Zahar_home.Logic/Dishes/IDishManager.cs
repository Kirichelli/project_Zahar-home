
namespace project_Zahar_home.Logic.Dishes
{
    public interface IDishManager
    {
        Task<IList<Dish>> GetAll();
        Task Create(Dish dish);
        Task Delete(int id);
        Task<IList<Dish>> nameFilter(string name);
        Task<Dish> getDish(int id);
        Task changeRating(int id, int rating);
    }
}
