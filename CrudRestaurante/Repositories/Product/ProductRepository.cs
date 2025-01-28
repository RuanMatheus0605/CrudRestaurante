using CrudRestaurante.Context;
using CrudRestaurante.Model;
using CrudRestaurante.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace CrudRestaurante.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<List<ProductModel>> GetAll()
        {
            List<ProductModel> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<ProductModel> GetId(int id)
        {
            ProductModel product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            return product;
        }

        public async Task<ProductModel> Create(ProductModel newProduct)
        {
            _context.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<ProductModel> Edit(RequestProduct requestProduct, int id)
        {
            ProductModel product = await GetId(id);

            if (product == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            product.Name = requestProduct.Name;
            product.Description = requestProduct.Description;
            product.Price = requestProduct.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(int id)
        {
            ProductModel product = await GetId(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
