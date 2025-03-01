using Divarcheh.Domain.Core.Entities.Advertisement;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Http;
namespace Divarcheh.Domain.Core.Contracts.Service
{
    public interface IBaseDataService
    {
        Task<List<City>> GetCities(CancellationToken cancellationToken);
        Task<string> UploadImage(IFormFile FormFile , string folderName , CancellationToken cancellationToken);
        Task<List<Brand>> GetBrands(CancellationToken cancellationToken);
        Task AddAdvImages(List<string> imgAddress, int advId, CancellationToken cancellationToken);

    }
}
