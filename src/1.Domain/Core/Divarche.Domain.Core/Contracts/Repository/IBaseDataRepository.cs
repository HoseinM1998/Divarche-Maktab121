using Divarcheh.Domain.Core.Entities.Advertisement;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.User;

namespace Divarcheh.Domain.Core.Contracts.Repository
{
    public interface IBaseDataRepository
    {
        Task<List<City>> GetCities(CancellationToken cancellationToken);
        Task<List<Brand>> GetBrands(CancellationToken cancellationToken);
        Task AddAdvImages(List<string> imgAddress, int advId, CancellationToken cancellationToken);
    }
}
