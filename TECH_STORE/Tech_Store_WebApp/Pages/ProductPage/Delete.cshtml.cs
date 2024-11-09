using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tech_BussinessObjects;
using Tech_Services.Interface;

namespace Tech_Store_WebApp.Pages.ProductPage
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService context)
        {
            _productService = context;
        }

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
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _productService.GetProducts() == null)
            {
                return NotFound();
            }
            var product = _productService.GetProduct(id);

            if (product != null)
            {
                _productService.Delete(product);
            }

            return RedirectToPage("./Index");
        }
    }
}
