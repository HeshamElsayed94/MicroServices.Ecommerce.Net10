using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Mapster;
using Mediator;

namespace Catalog.Application.Handlers.Queries;

public class GetAllTypesQueryHanlder(ITypeRepository typeRepository)
: IQueryHandler<GetAllTypesQuery, IList<TypeResponseDto>>

{
	public async ValueTask<IList<TypeResponseDto>> Handle(GetAllTypesQuery query, CancellationToken cancellationToken)
	{
		var brands = await typeRepository.GetAllTypesAsync(cancellationToken);

		var brandsResponseDto = brands.Adapt<IList<TypeResponseDto>>();

		return brandsResponseDto;
	}
}