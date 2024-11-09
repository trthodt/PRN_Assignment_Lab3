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
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService context)
        {
            _productService = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_productService.GetProducts() != null)
            {
                Product = _productService.GetProducts();
            }
        }

        public IActionResult OnPostSearch()
        {
            string query = Request.Form["query"];
            if (string.IsNullOrEmpty(query))
            {
                query = "";
            }

            var results = _productService.SearchByName(query);
            Product = results;

            return Page();
        }
    }
}
