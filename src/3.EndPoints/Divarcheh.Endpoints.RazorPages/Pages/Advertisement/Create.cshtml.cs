using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Divarcheh.Domain.Core.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Pages.Advertisement
{
    public class CreateModel : PageModel
    {
        private readonly IAdvertisementAppService _advertisementAppService;

        [BindProperty]
        public GetForItemsOutputDto FormItems { get; set; }

        [BindProperty] 
        public Model InputModel { get; set; }

        [BindProperty] public int ChildCategoryId { get; set; }

        public class Model
        {
            public AdvertisementTypeEnum TypeEnum { get; set; }
            public string Title { get; set; }
            public List<IFormFile> Images { get; set; }
            public AdvertisementStatusEnum StatusEnum { get; set; }
            public int Price { get; set; }
            public int BrandId { get; set; }
            public string AdvModel { get; set; }
            public string Description { get; set; }
            public int UserId { get; set; }
            public int CityId { get; set; }
            public int CategoryId { get; set; }

        }

        public CreateModel(IAdvertisementAppService advertisementAppService)
        {
            _advertisementAppService = advertisementAppService;

        }

        public async Task OnGet(int childCategoryId , CancellationToken cancellationToken)
        {
            ChildCategoryId = childCategoryId;
            FormItems = await _advertisementAppService.GetForItems(childCategoryId, cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var userId = User;
            await _advertisementAppService.Create(new CreateAdvertisementDto()
            {
                Title = InputModel.Title,
                Price = InputModel.Price,
                BrandId = InputModel.BrandId,
                Model = InputModel.AdvModel,
                Description = InputModel.Description,
                AdvertisementType = InputModel.TypeEnum,
                AdvertisementStatus = InputModel.StatusEnum,
                Images = InputModel.Images,
                UserId = int.Parse(UserTools.GetUserId(User.Claims)),
                CityId = int.Parse(UserTools.GetCityId(User.Claims)),
                CategoryId = ChildCategoryId
            }, cancellationToken);

            return Page();
        }
    }
}
