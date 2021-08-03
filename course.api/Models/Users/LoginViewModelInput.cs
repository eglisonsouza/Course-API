using System;
using System.ComponentModel.DataAnnotations;

namespace course.api.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public String Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        public String Password { get; set; }
    }
}