using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface ITypeRepository
{
	Task<IEnumerable<ProuductType>> GetAllTypesAsync(CancellationToken cancellationToken = default);
}
