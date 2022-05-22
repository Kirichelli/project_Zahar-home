namespace project_Zahar_home.Storage.Entities
{
    public class Rating
    {
        [Key]
        public int Rating_Id { get; set; }

        public int Rating_Value { get; set; }
        [Required]
        public int User_Id { get; set; }
        [ForeignKey(nameof(User_Id))]
        public virtual User User { get; set; }


/*        [Required]
        public int Dish_Id { get; set; }

        [ForeignKey(nameof(Dish_Id))]
        public virtual Dish Dish { get; set }*/
    };
}
