namespace project_Zahar_home.Storage.Entities
{
    public class Dish
    {
        [Key]
        public int Dish_Id { get; set; }
        [ForeignKey(nameof(Dish_Id))]
        public virtual Rating Rating { get; set; }
        public string Name_Dish { get; set; }
        public string Discription { get; set; }
        public string Ingredients { get; set; }
        public int Calories { get; set; }
        public int Cook_Time { get; set; }
        public string Level { get; set; }
        public int Category_id { get; set; }
        public int Rating_id { get; set; }
        public int Type_Id { get; set; }

        [ForeignKey(nameof(Type_Id))]
        public virtual Type_Of_Kitchen Type_Of_Kitchen { get; set; }
    }
}
