using System.Data.SqlClient;

namespace TechStore.Models
{
    public class Product
    {
        public int id { get; set; }
        public String titre { get; set; }
        public int prix { get; set; }
        public int compare_prix { get; set; }
        public String images { get; set; }
        public bool inStock { get; set; }

        public int categoryID { get; set; }
        public Category category { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
 