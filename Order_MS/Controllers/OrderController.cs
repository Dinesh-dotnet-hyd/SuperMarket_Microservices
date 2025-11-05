using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_MS.Models;

namespace Order_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _repo;
        private readonly HttpClient _client;
        public OrderController(OrderDbContext orderDbContext, IHttpClientFactory httpClientFactory)
        {
            _repo = orderDbContext;
            _client = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int productId, int quantity)
        {
            var product = await _client.GetFromJsonAsync<ProductDto>($"http://localhost:5043/api/Product/{productId}");
            if(product == null ) return NotFound(" Profuct Not Available");
            var total = product.Price * quantity;
            var order = new Orders { ProductId=productId, Quantity=quantity, TotalAmount=total};
            _repo.orders.Add(order);
            await _repo.SaveChangesAsync();
            return Ok(order);
        }


    }
}
