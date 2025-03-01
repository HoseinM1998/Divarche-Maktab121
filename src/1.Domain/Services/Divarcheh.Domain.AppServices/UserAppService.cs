using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Contracts.Service;
using Divarcheh.Domain.Core.Dto.User;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Divarcheh.Domain.Core.Enum;

namespace Divarcheh.Domain.AppServices;
public class UserAppService : IUserAppService
{
    private readonly IUserService _userService;
    private readonly IBaseDataService _baseDataService;


    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserAppService(IUserService userService, IBaseDataService baseDataService, UserManager<User> userManager, SignInManager<User> signInManager, IPasswordHasher<User> passwordHasher)
    {
        _userService = userService;
        _baseDataService = baseDataService;
        _userManager = userManager;
        _signInManager = signInManager;
        _passwordHasher = passwordHasher;
    }

    public int GetCount() => _userService.GetCount();
    public List<UserSummaryDto> GetAll() => _userService.GetAll();


    public async Task<IdentityResult> Register(UserDto model, CancellationToken cancellationToken)
    {
        string role = string.Empty;


        var user = new User
        {
            UserName = model.UserName,
            Email = model.Email,
            Mobile = model.Mobile,
            CityId = model.CityId,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        if (model.Role == RoleEnum.Admin)
        {
            role = "Admin";
        }

        if (model.Role == RoleEnum.Visitor)
        {
            role = "Visitor";
            user.Visitor = new Visitor()
            {
                VisitCount = 1,
                LastVisit = DateTime.Now
            };
        }

        if (model.Role == RoleEnum.Advertiser)
        {
            role = "Advertiser";
            user.Advertiser = new Advertiser()
            {
               Balance = 1000
            };
        }

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            if (model.ProfileImgFile is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
            }

            await _userManager.AddToRoleAsync(user, role);

            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
            await _userManager.AddClaimAsync(user, new Claim("CityId", user.CityId.ToString()));
            await _userManager.AddClaimAsync(user, new Claim("FullName", $"{user.FirstName} {user.LastName}"));

            if (model.Role == RoleEnum.Visitor)
            {
               await _userManager.AddClaimAsync(user, new Claim("VisitorId", user.Visitor.Id.ToString()));
            }

            if (model.Role == RoleEnum.Advertiser)
            {
                await _userManager.AddClaimAsync(user, new Claim("AdvertiserId", user.Advertiser.Id.ToString()));
            }

            await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);

        }

        return result;
    }

    public UserDto GetById(int id) => _userService.GetById(id);
    public async Task<bool> Update(UserDto model, CancellationToken cancellationToken)
    {
        if (model.ProfileImgFile is not null)
        {
            model.ImagePath = await _baseDataService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
        }

        return await _userService.Update(model, cancellationToken);
    }

    public async Task<IdentityResult> Login(string username, string password, bool rememberMe)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);

        return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
    }
}