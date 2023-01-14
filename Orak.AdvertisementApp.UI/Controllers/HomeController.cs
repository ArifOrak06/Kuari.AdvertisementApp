  using Microsoft.AspNetCore.Mvc;
using Orak.AdvertisementApp.Business.İnterfaces;
using Orak.AdvertisementApp.UI.Extensions;

namespace Orak.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetActiveAsync();
            return this.ResponseView(response);
        }
    }
}
