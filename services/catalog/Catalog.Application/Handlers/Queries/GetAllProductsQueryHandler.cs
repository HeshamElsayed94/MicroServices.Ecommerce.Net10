using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Queries;

public class GetAllProductsQueryHandler(IProductRepository productRepository)
: IQueryHandler<GetAllProductsQuery, IList<ProductResponseDto>>
{
	public async ValueTask<IList<ProductResponseDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
	{
		var products = await productRepository.GetAllProductsAsync(cancellationToken);
		var productsResponseDto = products.Adapt<IList<ProductResponseDto>>();
		return productsResponseDto;
	}
}