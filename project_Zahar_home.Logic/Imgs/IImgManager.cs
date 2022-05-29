
namespace project_Zahar_home.Logic.Imgs
{
    public interface IImgManager
    {
        Task<Img> GetDishImage(int DishId);
        Task<IList<Img>> GetAll();
    }
}
