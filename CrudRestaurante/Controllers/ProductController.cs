using CrudRestaurante.Context;
using CrudRestaurante.Model;
using CrudRestaurante.Model.Requests;
using CrudRestaurante.Repositories.Product;
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
        private readonly IProductRepository _productRepository;
        public ProductController(AppDbContext appDbContext, IProductRepository productRepository)
        {
            _context = appDbContext;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<ProductModel> products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProductModel product = await _productRepository.GetId(id);
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
            ProductModel createdProduct = await _productRepository.Create(newProduct);
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] RequestProduct requestProduct, int id)
        {
            ProductModel product = await _productRepository.Edit(requestProduct, id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _productRepository.Delete(id);

            if (response == false)
            {
                return NotFound(new { Message = "Produto não encontrado" });
            }

            return Ok(new { Message = "Produto removido com sucesso" });
        }

    }
}
