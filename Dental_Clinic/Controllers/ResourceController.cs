using Dental_Clinic.Languages;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.AccessControl;

namespace Dental_Clinic.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _SharedResources;
        public ResourceController(IStringLocalizer<SharedResource> sharedResouces)
        {
            _SharedResources = sharedResouces;
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture,string returnUrl)
        {
            Response.Cookies.Append(

                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }

                );

            return LocalRedirect(returnUrl);

        }
    }
}
