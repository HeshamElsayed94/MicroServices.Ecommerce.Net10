using Catalog.Application.Responses;
using Mediator;

namespace Catalog.Application.Queries;

public record GetProductsByNameQuery(string Name) : IQuery<IList<ProductResponseDto>>;