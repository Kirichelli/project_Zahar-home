namespace project_Zahar_home.Storage.Entities
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Password { get; set; }

        public string Email { get; set; }

        [Required]
        public int Favourite_Id { get; set; }

       [ForeignKey(nameof(Favourite_Id))]
       public virtual Favourite Favourite { get; set; }
    }
}
