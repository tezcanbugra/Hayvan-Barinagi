using System.ComponentModel.DataAnnotations;

namespace Hayvan_Barınağı.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="Parola en az 3 karakterden oluşmalıdır.")]
        public string Password { get; set; }
    }
}
