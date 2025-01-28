using CrudRestaurante.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudRestaurante.Context
{
    public class AppDbContext : DbContext
    {
        
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ClientModel> Clients { get; set; }

    }
}
