

namespace TechStore.Models
{
    public class Order
    {
        public int id { get; set; }

        public int userId { get; set; } 
        public int productId { get; set; } 
        public User user { get; set; }
        public Product product { get; set; }
    }
}
