using Catalog.Application.Responses;
using Mediator;

namespace Catalog.Application.Queries;

public record GetAllProductsQuery() : IQuery<IList<ProductResponseDto>>;