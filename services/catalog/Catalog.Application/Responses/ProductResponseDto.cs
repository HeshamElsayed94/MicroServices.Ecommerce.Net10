using Catalog.Core.Entities;

namespace Catalog.Application.Responses;

public record ProductResponseDto(
	string Id,
	string Name,
	string Description,
	string Summary,
	string ImageFile,
	decimal Price,
	ProductBrand Brand,
	ProductType Type);