using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tech_BussinessObjects;
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace Tech_Store_WebApp.Pages.OrderPage
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        public IList<OrderDetail> OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            // Fetch order details by Order ID
            OrderDetails = _orderDetailService.GetOrderDetailByOrderId(orderId);

            if (OrderDetails == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
