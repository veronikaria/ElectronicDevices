using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicDevices.Models
{
    public class Order
    {
        [BindNever]  
        public int OrderId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        [MinLength(3, ErrorMessage = "Поле фамилии должно содержать не менее 3 символов")]
        [MaxLength(50, ErrorMessage = "Поле фамилии должно содержать менее 50 символов")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(3, ErrorMessage = "Поле имени должно содержать не менее 3 символов")]
        [MaxLength(50, ErrorMessage = "Поле имени должно содержать менее 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Страна")] 
        public string Country { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Город")] 
        public string City { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Phone]
        [Display(Name = "Номер")]
        public string Phone { get; set; }

        [Display(Name = "Почта")]
        [EmailAddress]
        public string Email { get; set; }

        [BindNever]
        public DateTime DateOrder { get; set; }

    }
}
