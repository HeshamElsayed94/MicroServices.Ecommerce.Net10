using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using Mediator;

namespace Catalog.Application.Handlers.Commands;

public class DeleteProductCommandHandler(IProductRepository productRepository)
	: ICommandHandler<DeleteProductCommand, bool>
{
	public async ValueTask<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
	{
		var result = await productRepository.DeleteProductByIdAsync(command.Id, cancellationToken);

		return result;
	}
}