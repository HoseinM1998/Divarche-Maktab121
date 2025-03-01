using System.Runtime.InteropServices.ComTypes;
using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Contracts.Service;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Divarcheh.Domain.Core.Entities.Advertisement;

namespace Divarcheh.Domain.AppServices
{
    public class AdvertisementAppService
        (IAdvertisementService advertisementService,
            IBaseDataService baseDataService,
            ICategoryService categoryService) : IAdvertisementAppService
    {
        public async Task Create(CreateAdvertisementDto model, CancellationToken cancellationToken)
        {
            var imagesPath = new List<string>();
            var advId = await advertisementService.Create(model, cancellationToken);

            if (model.Images is not null)
            {
                foreach (var image in model.Images)
                {
                    var imagePath = await baseDataService.UploadImage(image, "Advertiser", cancellationToken);
                    imagesPath.Add(imagePath);
                }

                await baseDataService.AddAdvImages(imagesPath, advId, cancellationToken);
            }
        }

        public async Task<GetForItemsOutputDto> GetForItems(int childId, CancellationToken cancellationToken)
        {
            var model = new GetForItemsOutputDto();

            model.CategoryData = await categoryService.GetDataForCreateAdv(childId, cancellationToken);
            model.Brands = await baseDataService.GetBrands(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<GetAdvertisementDto>> GetNewest(CancellationToken cancellationToken)
        {
            return await advertisementService.GetNewest(cancellationToken);
        }
    }
}
