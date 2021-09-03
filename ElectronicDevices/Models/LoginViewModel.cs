using System.ComponentModel.DataAnnotations;

namespace ElectronicDevices.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле имя пользователя есть обязательным")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле пароль есть обязательным")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
