using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Account.Pages
{
    public class RegisterModel (IUserAppService userAppService) : PageModel
    {
        [BindProperty]
        public UserDto User { get; set; }

        
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await userAppService.Register(User, cancellationToken);

            if (result.Succeeded)
            {
                return RedirectToPage("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page();
            }
        }
    }
}
