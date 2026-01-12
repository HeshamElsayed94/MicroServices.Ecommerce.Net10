using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProuductRepository
{
	Task<IEnumerable<Product>> GetAllProductsAsync();
	Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand);
	Task<IEnumerable<Product>> GetProductsByTypeAsync(string type);
	Task<Product> GetProductByIdAsync(string id);
	Task<Product> GetProductByNameAsync(string name);
	Task<Product> CreateProductAsync(Product product);
	Task<bool> UpdateProductAsync(Product product);
	Task<bool> DeleteProductByIdAsync(string id);
}
