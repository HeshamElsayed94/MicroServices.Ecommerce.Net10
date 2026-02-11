using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Mediator;

namespace Catalog.Application.Commands;

public record CreateProductCommand(
	string Name,
	string Description,
	string Summary,
	string ImageFile,
	decimal Price,
	ProductBrand Brand,
	ProductType Type
) : ICommand<ProductResponseDto>;