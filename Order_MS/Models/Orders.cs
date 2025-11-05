using System.ComponentModel.DataAnnotations;

namespace Order_MS.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
