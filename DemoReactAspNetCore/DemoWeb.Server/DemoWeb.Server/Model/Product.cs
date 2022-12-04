using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDesc { get; set; }
        [Required]
        public decimal ProductCost { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ProviderId { get; set; }

        public CategoryProduct Category { get; set; }

        public ProviderProduct Provider { get; set; }
    }
}


