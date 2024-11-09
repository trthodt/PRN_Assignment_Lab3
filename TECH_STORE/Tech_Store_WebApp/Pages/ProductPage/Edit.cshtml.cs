using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tech_BussinessObjects;
using Tech_Services.Interface;

namespace Tech_Store_WebApp.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        public EditModel(IProductService context)
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

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _productService.GetProducts() == null)
            {
                return NotFound();
            }

            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
           ViewData["CategoryId"] = new SelectList(categories, "Id", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                _productService.Update(Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
          return _productService.GetProduct(id)!= null;
        }
    }
}
