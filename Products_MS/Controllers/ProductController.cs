using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_MS.Models;

namespace Products_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Products.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> PostMethod(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var pro = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(pro);
        }
    }
}
