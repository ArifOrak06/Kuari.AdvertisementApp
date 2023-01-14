using Microsoft.AspNetCore.Mvc;
using Orak.AdvertisementApp.Common;

namespace Orak.AdvertisementApp.UI.Extensions
{
    public static class ControllerExtension 
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                // ValidationResult üzerinde dönelim ve bütün hataları ModelState'e ekleyip kullanıca gösterelim.
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                }
                return controller.View(response.Data); // hataların yazdırılmış olduğu datayı dönelim.
            }
            return controller.RedirectToAction(actionName);
        }
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName);
        }
    }
}
