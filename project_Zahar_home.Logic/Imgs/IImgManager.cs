
namespace project_Zahar_home.Logic.Imgs
{
    public interface IImgManager
    {
        Img GetDishImage(int DishId);
        IList<Img> GetAll();
    }
}
