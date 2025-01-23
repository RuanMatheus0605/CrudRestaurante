using CrudRestaurante.Context;
using CrudRestaurante.Model;
using CrudRestaurante.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<ProductModel> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProductModel product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestProduct productModel)
        {
            ProductModel newProduct = new ProductModel 
            { 
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
            };
            _context.Add(newProduct);
            await _context.SaveChangesAsync();

            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] RequestProduct requestProduct, int id)
        {
            
            ProductModel product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null) 
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            product.Name = requestProduct.Name;
            product.Description = requestProduct.Description;
            product.Price = requestProduct.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductModel product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                return NotFound(new { Message = $"Produto com ID {id} não encontrado." });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
