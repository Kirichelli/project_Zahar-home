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
        public int Cooked_Id { get; set; }

        [ForeignKey(nameof(Cooked_Id))]
        public virtual Cooked Cooked { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }

    
}
