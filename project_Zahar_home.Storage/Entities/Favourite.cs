namespace project_Zahar_home.Storage.Entities
{
    public class Favourite
    {
        [Key]
        public int Favourite_Id { get; set; }
        public List<Dish> favouriteDishes { get; set; }
    }
}
