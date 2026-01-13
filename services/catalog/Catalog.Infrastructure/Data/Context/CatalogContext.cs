using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context;

public class CatalogContext : ICatalogContext
{
	public CatalogContext(IConfiguration configuration)
	{
		var client = new MongoClient(configuration["DatabaseSetting:ConnectionString"]);

		var db = client.GetDatabase(configuration["DatabaseSetting:DatabaseName"]);

		Brands = db.GetCollection<ProductBrand>(configuration["DatabaseSetting:BrandsCollection"]);
		Types = db.GetCollection<ProductType>(configuration["DatabaseSetting:TypesCollection"]);
		Products = db.GetCollection<Product>(configuration["DatabaseSetting:ProductsCollection"]);

		_ = BrandContextSeed.SeedDataAsync(Brands);
		_ = TypeContextSeed.SeedDataAsync(Types);
		_ = CatalogContextSeed.SeedDataAsync(Products);
	}

	public IMongoCollection<ProductBrand> Brands { get; }

	public IMongoCollection<ProductType> Types { get; }

	public IMongoCollection<Product> Products { get; }
}
