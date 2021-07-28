using System;
using System.ComponentModel.DataAnnotations;

namespace course.api.Models.Users
{
    public class RegisterViewModelInput
    {

        [Required(ErrorMessage = "O Login é obrigatório")]
        public String Login { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public String Email { get; set; }
        
        [Required(ErrorMessage = "A Senha é obrigatório")]
        public String Password { get; set; }
    }
}