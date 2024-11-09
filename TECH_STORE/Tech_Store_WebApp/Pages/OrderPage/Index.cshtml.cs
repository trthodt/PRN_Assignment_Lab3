using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tech_BussinessObjects;
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace Tech_Store_WebApp.Pages.OrderPage
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public List<Order> Orders { get; set; }
        public int TotalOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;


        public async Task OnGetAsync()
        {
            Orders = _orderService.GetOrdersPagination(PageIndex, 5);
            TotalOrder = _orderService.Count();
        }
    }
}
