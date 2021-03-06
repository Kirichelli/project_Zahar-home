using System.ComponentModel.DataAnnotations;

namespace project_Zahar_home.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email/имя пользователя")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
