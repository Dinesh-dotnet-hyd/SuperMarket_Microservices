using System.ComponentModel.DataAnnotations;

namespace Products_MS.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category {  get; set; }
        public double Price { get; set; }
    }
}
