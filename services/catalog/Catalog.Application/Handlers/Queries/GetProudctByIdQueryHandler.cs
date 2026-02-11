using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Queries;

public class GetProudctByIdQueryHandler(IProductRepository prouductRepository)
: IQueryHandler<GetProductByIdQuery, ProductResponseDto>
{
	public async ValueTask<ProductResponseDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
	{
		var product = await prouductRepository.GetProductByIdAsync(query.Id, cancellationToken);

		return product.Adapt<ProductResponseDto>();
	}
}