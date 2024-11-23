using System.ComponentModel.DataAnnotations;
namespace RoughDraftInventoryManagmentSystem.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Product name is required.")]
		public string Name { get; set; }

		[Required]
		public string SKU { get; set; }

		[Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
		public decimal Price { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Quanitity cannot be negative")]
		public int Quantity { get; set; }

		public string ImageUrl { get; set; }

		// possible addition
		//public Product(int quantity)
		//{
		//	Quantity = quantity;
		//}
	}
}
