using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context;

public static class BrandContextSeed
{
	public static async Task SeedDataAsync(IMongoCollection<ProductBrand> brandcollection)
	{
		var hasData = await brandcollection.Find(_ => true).AnyAsync();

		if (hasData)
			return;

		var filePath = Path.Combine("Data", "SeedData", "brands.json");

		if (!File.Exists(filePath))
		{
			Console.WriteLine($"File path not found : {filePath}");
			return;
		}
		var fileData = await File.ReadAllTextAsync(filePath);

		var brands = JsonSerializer.Deserialize<List<ProductBrand>>(fileData);

		if (brands?.Count is > 0)
			await brandcollection.InsertManyAsync(brands);

	}
}
