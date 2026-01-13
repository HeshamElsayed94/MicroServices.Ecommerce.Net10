using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context;

public static class TypeContextSeed
{
	public static async Task SeedDataAsync(IMongoCollection<ProductType> typeCollection)
	{
		if (await typeCollection.Find(_ => true).AnyAsync())
			return;

		var filePath = Path.Combine("Data", "SeedData", "types.json");
		if (!Path.Exists(filePath))
		{
			Console.WriteLine($"Seed file not exists : {filePath}");
			return;
		}

		var typesData = await File.ReadAllTextAsync(filePath);
		var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

		if (types?.Count is > 0)
			await typeCollection.InsertManyAsync(types);
	}
}
