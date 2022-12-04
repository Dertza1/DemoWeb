using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Models
{
    public class ProductDto
    { 
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductCost { get; set; }
        public int CategoryId { get; set; }
        public int ProviderId { get; set; }
    }
}
