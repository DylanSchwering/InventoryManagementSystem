using RoughDraftInventoryManagmentSystem.Models;
using RoughDraftInventoryManagmentSystem.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RoughDraftInventoryManagmentSystem.Services
{

	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync();
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product updatedProduct);
		Task DeleteProductAsync(int id);
	}

	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _context;

		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task AddProductAsync(Product product)
		{
			try
			{
				await _context.Products.AddAsync(product);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				// Log error (consider using ILogger)
				throw new Exception("An error occured while adding the product.", ex);
			}
		}

		public async Task UpdateProductAsync(Product updatedProduct)
		{
			var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = updatedProduct.Name;
				existingProduct.SKU = updatedProduct.SKU;
				existingProduct.Price = updatedProduct.Price;
				existingProduct.Quantity = updatedProduct.Quantity;
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new KeyNotFoundException($"Product with ID {updatedProduct.Id} not found.");
			}
		}

		public async Task DeleteProductAsync(int id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p =>p.Id == id);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new KeyNotFoundException($"Product with ID {id} not found.");
			}
		}


		public List<Product> GetProducts()
		{
			return _context.Products.ToList();
		}

		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public void UpdateProduct(Product updatedProduct)
		{
			var existingProduct = _context.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = updatedProduct.Name;
				existingProduct.SKU = updatedProduct.SKU;
				existingProduct.Price = updatedProduct.Price;
				existingProduct.Quantity = updatedProduct.Quantity;
				_context.SaveChanges();
			}
		}

		public void DeleteProduct(int id)
		{
			var product = _context.Products.FirstOrDefault(p => p.Id == id);
			if (product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
			}
		}

	}
}
