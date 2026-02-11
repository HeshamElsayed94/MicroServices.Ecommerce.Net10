using Catalog.Application.Responses;
using Mediator;

namespace Catalog.Application.Queries;

public record GetProductsByBrandQuery(string Brand) : IQuery<IList<ProductResponseDto>>;