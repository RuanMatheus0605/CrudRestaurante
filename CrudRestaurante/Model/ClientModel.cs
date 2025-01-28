using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRestaurante.Model
{
    [Table("Clientes")]
    public class ClientModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Name { get; set; }
        [Column("Endereco")]
        public string Address { get; set; }
    }
}
