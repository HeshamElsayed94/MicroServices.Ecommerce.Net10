using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Queries;

public class GetAllBrandsQueryHanlder(IBrandRepository brandRepository)
: IQueryHandler<GetAllBrandsQuery, IList<BrandResponseDto>>

{
	public async ValueTask<IList<BrandResponseDto>> Handle(GetAllBrandsQuery query, CancellationToken cancellationToken)
	{
		var brands = await brandRepository.GetAllBrandsAsync(cancellationToken);

		var brandsResponseDto = brands.Adapt<IList<BrandResponseDto>>();

		return brandsResponseDto;
	}
}