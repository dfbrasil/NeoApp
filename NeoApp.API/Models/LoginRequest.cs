using System.ComponentModel.DataAnnotations;

namespace NeoApp.API.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; }
    }
}
