using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Models
{
    [Table("Categories")]
    public class CategoryProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}

