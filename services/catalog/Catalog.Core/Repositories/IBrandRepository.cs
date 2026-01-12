using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IBrandRepository
{
	Task<IEnumerable<ProuductBrand>> GetAllBrandsAsync(CancellationToken cancellationToken = default);
}
