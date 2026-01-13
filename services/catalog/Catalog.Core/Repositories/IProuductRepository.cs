using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProuductRepository
{
	Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand, CancellationToken cancellationToken = default);
	Task<IEnumerable<Product>> GetProductsByTypeAsync(string type, CancellationToken cancellationToken = default);
	Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken = default);
	Task<Product> GetProductByNameAsync(string name, CancellationToken cancellationToken = default);
	Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken = default);
	Task<bool> UpdateProductAsync(Product product, CancellationToken cancellationToken = default);
	Task<bool> DeleteProductByIdAsync(string id, CancellationToken cancellationToken = default);
}
