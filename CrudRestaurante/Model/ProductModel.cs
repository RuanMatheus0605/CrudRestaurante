using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRestaurante.Model
{
    [Table("Produtos")]
    public class ProductModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Name { get; set; }
        [Column("descricao")]
        public string Description { get; set; }
        [Column("preco")]
        public int Price { get; set; }

        internal static async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
