using Divarcheh.Domain.AppServices;
using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Entities.Configs;
using Divarcheh.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Account.Pages
{

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginModel(SiteSettings siteSettings , IUserAppService userAppService) : PageModel
    {

        [BindProperty]
        public LoginViewModel PageModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await userAppService.Login(PageModel.Username, PageModel.Password,true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty ,"نام کاربری یا کلمه عبور اشتباه است.");
                return Page();
            }

            var userRole = UserTools.GetRole(User.Claims);

            return userRole switch
            {
                "Admin" => RedirectToPage("Index", new { area = "Admin" }),
                "Visitor" => RedirectToPage("Index", new { area = "Visitor" }),
                "Advertiser" => RedirectToPage("Index", new { area = "Advertiser" }),
                _ => RedirectToPage("Login"),
            };
        }
    }
}
