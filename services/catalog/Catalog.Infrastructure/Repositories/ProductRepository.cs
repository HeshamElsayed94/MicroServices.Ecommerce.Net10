using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Context;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext context) : IProductRepository, IBrandRepository, ITypeRepository
{
	public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken = default)
	{
		await context.Products.InsertOneAsync(product, cancellationToken: cancellationToken);
		return product;
	}

	public async Task<bool> DeleteProductByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		return await context.Products.DeleteOneAsync(p => p.Id == id, cancellationToken) is DeleteResult result && result.DeletedCount > 0;
	}

	public async Task<IEnumerable<ProductBrand>> GetAllBrandsAsync(CancellationToken cancellationToken = default)
	{
		return await context.Brands.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);
	}

	public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
	{
		return await context.Products.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);
	}

	public async Task<IEnumerable<ProductType>> GetAllTypesAsync(CancellationToken cancellationToken = default)
	{
		return await context.Types.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);
	}

	public async Task<Product?> GetProductByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
	}

	public async Task<Product> GetProductByNameAsync(string name, CancellationToken cancellationToken = default)
	{
		return await context.Products.Find(p => p.Name == name).FirstOrDefaultAsync(cancellationToken: cancellationToken);
	}

	public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand, CancellationToken cancellationToken = default)
	{
		return await context.Products.Find(p => p.Brand.Name == brand).ToListAsync(cancellationToken: cancellationToken);
	}

	public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string type, CancellationToken cancellationToken = default)
	{
		return await context.Products.Find(p => p.Type.Name == type).ToListAsync(cancellationToken: cancellationToken);
	}

	public async Task<bool> UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
	{
		var updatedProduct = await context.Products.ReplaceOneAsync(p => p.Id == product.Id, product, cancellationToken: cancellationToken);

		return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
	}
}