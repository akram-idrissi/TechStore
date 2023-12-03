using System.ComponentModel.DataAnnotations;

namespace TechStore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string password { get; set; }
        public bool RememberMe { get; set; }
    }
}
