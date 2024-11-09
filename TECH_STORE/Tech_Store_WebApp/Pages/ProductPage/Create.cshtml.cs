using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tech_BussinessObjects;
using Tech_Services.Interface;

namespace Tech_Store_WebApp.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateModel(IProductService context)
        {
            _productService = context;
        }

        List<Category> categories = new List<Category>
         {
             new Category { Id = 1, CategoryName = "Electronics" },
             new Category { Id = 2, CategoryName = "Home Appliances" },
             new Category { Id = 3, CategoryName = "Computers & Accessories" },
             new Category { Id = 4, CategoryName = "Smart Devices" },
             new Category { Id = 5, CategoryName = "Gaming" }
         };

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(categories, "Id", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _productService.GetProducts() == null || Product == null)
            {
                return Page();
            }

            _productService.Create(Product);

            return RedirectToPage("./Index");
        }
    }
}
