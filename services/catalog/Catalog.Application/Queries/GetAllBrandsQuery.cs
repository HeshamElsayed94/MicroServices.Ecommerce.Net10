using Catalog.Application.Responses;
using Mediator;

namespace Catalog.Application.Queries;

public record GetAllBrandsQuery() : IQuery<IList<BrandResponseDto>>;