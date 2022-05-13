namespace project_Zahar_home.Storage.Entities
{
    public class Favourite
    {
        [Key]
        public int Favourite_Id { get; set; }
        [Required]
        public int Dish_Id { get; set; }
        
        [ForeignKey(nameof(Dish_Id))]
        public virtual Dish Dish { get; set; }
    }
}
