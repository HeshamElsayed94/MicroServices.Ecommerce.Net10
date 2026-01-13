using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context;

public static class CatalogContextSeed
{
	public static async Task SeedDataAsync(IMongoCollection<Product> productCollection)
	{
		if (await productCollection.Find(_ => true).AnyAsync())
			return;

		var filePath = Path.Combine("Data", "SeedData", "products.json");
		if (!Path.Exists(filePath))
		{
			Console.WriteLine($"Seed file not exists : {filePath}");
			return;
		}

		var productsData = await File.ReadAllTextAsync(filePath);
		var products = JsonSerializer.Deserialize<List<Product>>(productsData);

		if (products?.Count is > 0)
			await productCollection.InsertManyAsync(products);
	}
}
