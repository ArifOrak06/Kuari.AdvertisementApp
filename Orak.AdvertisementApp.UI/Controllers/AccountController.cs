using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orak.AdvertisementApp.Business.İnterfaces;
using Orak.AdvertisementApp.Common.Enums;
using Orak.AdvertisementApp.Dtos;
using Orak.AdvertisementApp.UI.Extensions;
using Orak.AdvertisementApp.UI.Models;
using System.Security.Claims;

namespace Orak.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IGenderService _genderService;
        private readonly IValidator<AppUserCreateModel> _appUserCreateValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<AppUserCreateModel> appUserCreateValidator, IAppUserService appUserService, IMapper mapper, IValidator<AppUserLoginDto> loginDtoValdator)
        {
            _genderService = genderService;
            _appUserCreateValidator = appUserCreateValidator;
            _appUserService = appUserService;
            _mapper = mapper;
            
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new AppUserCreateModel
            {
                Genders = new SelectList(response.Data,"Id","Definition") 
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserCreateModel model)
        {
            var result = _appUserCreateValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto,(int)RoleType.Member);
                return this.ResponseRedirectToAction(createResponse, "SignIn");
          
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition");
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View(new AppUserLoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto )
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);
          
                var claims = new List<Claim>();

                if (roleResult.ResponseType == Common.ResponseType.Success)
                {
                    
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }

              
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);

            return View(dto);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}
