using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Commands;

public class CreateProductCommandHandler(IProductRepository productRepository)
: ICommandHandler<CreateProductCommand, ProductResponseDto>
{
	public async ValueTask<ProductResponseDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		var productEntity = command.Adapt<Product>();

		var newProduct = await productRepository.CreateProductAsync(productEntity, cancellationToken);

		return newProduct.Adapt<ProductResponseDto>();
	}
}