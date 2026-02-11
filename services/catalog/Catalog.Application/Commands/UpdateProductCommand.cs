using Catalog.Core.Entities;
using Mediator;

namespace Catalog.Application.Commands;

public record UpdateProductCommand(
	string Id,
	string Name,
	string Description,
	string Summary,
	string ImageFile,
	decimal Price,
	ProductBrand Brand,
	ProductType Type
) : ICommand<bool>;