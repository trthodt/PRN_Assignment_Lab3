using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Tech_Services.Interface;
using Tech_BussinessObjects;

namespace Tech_Store_WebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Message { get; set; }

        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Return the page with validation errors
                return Page();
            }

            // Find user by email
            User user = _userService.FindUserByEmail(Email);

            // Check if user exists
            if (user == null)
            {
                Message = "Invalid Email or Password";
                return Page();
            }

            // Validate password (assuming user has a Password property for simplicity)
            if (user.Password != Password)
            {
                Message = "Invalid Email or Password";
                return Page();
            }
            if (!user.Role.Equals("admin")) {
                Message = "You don't have permision to access this application";
                return Page();
            }
            HttpContext.Session.SetString("Role", user.Role);
            // Redirect to ProductPage on successful login
            return RedirectToPage("/ProductPage/Index");
        }
    }
}
