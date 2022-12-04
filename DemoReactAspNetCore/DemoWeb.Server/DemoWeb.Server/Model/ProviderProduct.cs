using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Models
{
    [Table("Providers")]
    public class ProviderProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProviderName { get; set; }

    }
}

