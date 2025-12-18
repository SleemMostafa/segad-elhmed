using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace segad_elhmd.Controllers;

[Route("[controller]/[action]")]
public class CultureController(ILogger<CultureController> logger) : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        logger.LogInformation("Setting culture to {Culture}", culture);
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }

        return LocalRedirect(redirectUri);
    }
}
