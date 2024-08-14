using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }
        [Required]
        public decimal? ProductPrice { get; set; }
        [Required]
        [StringLength(500)]
        public string? ProductDescription { get; set; }
        [Required]
        public int? ProductQuantity { get; set; }
        [StringLength(50)]
        public string? ProductImage { get; set; }
		
		[ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
		
		[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
