using Mediator;

namespace Catalog.Application.Commands;

public record DeleteProductCommand(string Id) : ICommand<bool>;