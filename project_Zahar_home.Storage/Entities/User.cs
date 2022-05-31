namespace project_Zahar_home.Storage.Entities
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string UserName { get; set; }

        public int? Cooked_Id { get; set; }

        [ForeignKey(nameof(Cooked_Id))]
        public virtual Cooked Cooked { get; set; }

        public int? RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        /*public virtual Dictionary<Rating, int> Ratings { get; set; }*/
        public string? Photo { get; set; }


    }


}
