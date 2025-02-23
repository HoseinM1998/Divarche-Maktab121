using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.Dashboard;
using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IDashboardAppService _dashboardAppService;


        public IndexModel(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        [BindProperty]
        public StatisticsDataDto DashboardData { get; set; }

        public void OnGet()
        {
            TempData["Menu-Users"] = string.Empty;
            TempData["Menu-Dashboard"] = "current";

            var data = User;
            DashboardData = _dashboardAppService.GetStatisticsData();
        }
    }
}
