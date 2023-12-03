using System.ComponentModel.DataAnnotations;

namespace TechStore.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a nom.")]
        [StringLength(30)]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
