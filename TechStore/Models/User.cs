using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace TechStore.Models
{
    public class User : IdentityUser
    {
        
        // navigation property to linking entity
        public ICollection<Order> orders { get; set; }


    }
}
