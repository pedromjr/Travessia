using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class UserLoginCredentials
    {
        [DisplayName("Nome:")]
        public string Name { get; set; }

        [DisplayName("Email:")]
        public string Email { get; set; }

        [DisplayName("Login:")]
        [Required(ErrorMessage = "Login é obrigatório.")]
        public string Login { get; set; }

        [DisplayName("Senha:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string Password { get; set; }

        [DisplayName("Senha:")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}