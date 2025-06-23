using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace LibraryRazorManager.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet(string culture)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                var cultureInfo = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }
    }
}
