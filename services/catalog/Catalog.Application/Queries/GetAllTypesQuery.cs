using Catalog.Application.Responses;
using Mediator;

namespace Catalog.Application.Queries;

public record GetAllTypesQuery() : IQuery<IList<TypeResponseDto>>;