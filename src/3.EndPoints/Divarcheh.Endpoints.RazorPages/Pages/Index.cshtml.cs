using Divarcheh.Domain.AppServices;
using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Entities.Advertisement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Pages
{
    public class IndexModel (IAdvertisementAppService advertisementAppService) : PageModel
    {
        [BindProperty] public IEnumerable<GetAdvertisementDto> NewestAdvertisement { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            NewestAdvertisement = await advertisementAppService.GetNewest(cancellationToken);
        }
    }
}
