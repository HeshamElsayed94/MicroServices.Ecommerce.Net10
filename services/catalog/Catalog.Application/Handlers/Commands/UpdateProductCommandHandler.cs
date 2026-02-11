using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Commands;

public class UpdateProductCommandHandler(IProductRepository productRepository)
: ICommandHandler<UpdateProductCommand, bool>
{
	public async ValueTask<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
	{
		var productEntity = command.Adapt<Product>();

		var result = await productRepository.UpdateProductAsync(productEntity, cancellationToken);

		return result;
	}
}