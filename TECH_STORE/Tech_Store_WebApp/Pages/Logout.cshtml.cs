using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Store_WebApp.Pages
{
    public class LogoutModel : PageModel
    {
        public RedirectToPageResult OnGet()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login");
        }
    }
}
