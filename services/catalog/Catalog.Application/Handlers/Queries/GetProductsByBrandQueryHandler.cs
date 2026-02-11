using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Queries;

public class GetProductsByBrandQueryHandler(IProductRepository productRepository)
: IQueryHandler<GetProductsByBrandQuery, IList<ProductResponseDto>>
{
	public async ValueTask<IList<ProductResponseDto>> Handle(GetProductsByBrandQuery query, CancellationToken cancellationToken)
	{
		var products = await productRepository.GetProductsByBrandAsync(query.Brand, cancellationToken);

		return products.Adapt<IList<ProductResponseDto>>();
	}
}