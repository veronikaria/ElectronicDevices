using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDevices.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле имя пользователя есть обязательным")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Поле почта есть обязательным")]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароль есть обязательным")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердить пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле подтвердить пароль есть обязательным")]
        public string ConfirmPassword { get; set; }

    }
}
