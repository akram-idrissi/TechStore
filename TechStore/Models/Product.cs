using System.Data.SqlClient;

namespace TechStore.Models
{
    public class Product
    {
        public int id { get; set; }
        public String nom { get; set; }
        public String description { get; set; }
        public int prix { get; set; }
        public int reviews { get; set; }
        public int stockQt { get; set; }
        public String[] images { get; set; }
        public bool inStock { get; set; }

        public int categoryID { get; set; }
        public Category category { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
 