using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orak.AdvertisementApp.Business.İnterfaces;
using Orak.AdvertisementApp.Dtos;
using Orak.AdvertisementApp.UI.Models;
using System.Security.Claims;

namespace Orak.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AdvertisementController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
           
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
          
            var userResponse= await _appUserService.GetByIdAsync<AppUserListDto>(userId);
            ViewBag.GenderId = userResponse.Data.GenderId;

            return View(new AdvertisementAppUserCreateModel
            {
                AppUserId = userId,
                AdvertisementId = advertisementId
            });
        }
    }
}
