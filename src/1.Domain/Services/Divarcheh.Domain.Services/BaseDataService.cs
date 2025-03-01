using Divarcheh.Domain.Core.Contracts.Repository;
using Divarcheh.Domain.Core.Contracts.Service;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Divarcheh.Domain.Core.Entities.Advertisement;

namespace Divarcheh.Domain.Services
{
    public class BaseDataService : IBaseDataService
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public BaseDataService(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }

        public async Task<List<City>> GetCities(CancellationToken cancellationToken)
            => await _baseDataRepository.GetCities(cancellationToken);

        public async Task<string> UploadImage(IFormFile FormFile , string folderName , CancellationToken cancellation)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine($"wwwroot/images/{folderName}", fileName);
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                       await FormFile.CopyToAsync(stream,cancellation);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return $"/images/{folderName}/{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }

        public async Task<List<Brand>> GetBrands(CancellationToken cancellationToken)
            => await _baseDataRepository.GetBrands(cancellationToken);

        public async Task AddAdvImages(List<string> imgAddress, int advId, CancellationToken cancellationToken)
        {
            await _baseDataRepository.AddAdvImages(imgAddress, advId, cancellationToken);
        }
    }
}
