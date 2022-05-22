namespace project_Zahar_home.Storage.Entities
{
    public class Rating
    {
        [Key]
        public int Rating_Id { get; set; }

        public int Rating_Value { get; set; }
/*        public int Rating_user_id { get; set; }
        [ForeignKey(nameof(Rating_user_id))]
        public virtual Rating_user Rating_user { get; set; }
*/


        [Required]
        public int Dish_Id { get; set; }

        [ForeignKey(nameof(Dish_Id))]
        public virtual Dish Dish { get; set; }
    }
}
