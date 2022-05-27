namespace project_Zahar_home.Storage.Entities
{
    public class Rating
    {
        [Key]
        public int Rating_Id { get; set; }
        public virtual Dictionary<User,int> Users { get; set; }
        public Rating()
        {
            Users = new Dictionary<User,int>();
        }
        public double Rating_Value { get; set; }
        //[Required]
        //public int User_Id { get; set; }
        //[ForeignKey(nameof(User_Id))]
        //public virtual User User { get; set; }

        public int Dish_Id { get; set; }

        [ForeignKey(nameof(Dish_Id))]
        public virtual Dish Dish { get; set; }
    };
}
