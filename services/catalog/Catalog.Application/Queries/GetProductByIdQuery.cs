using Catalog.Application.Responses;
using Mediator;

namespace Catalog.Application.Queries;

public record GetProductByIdQuery(string Id) : IQuery<ProductResponseDto>;