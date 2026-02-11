using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Queries;

public class GetProductsByNameQueryHandler(IProductRepository prouductRepository)
: IQueryHandler<GetProductsByNameQuery, IList<ProductResponseDto>>
{
	public async ValueTask<IList<ProductResponseDto>> Handle(GetProductsByNameQuery query, CancellationToken cancellationToken)
	{
		var products = await prouductRepository.GetProductByNameAsync(query.Name, cancellationToken);

		return products.Adapt<IList<ProductResponseDto>>();
	}
}