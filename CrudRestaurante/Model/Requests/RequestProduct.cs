using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRestaurante.Model.Requests
{
    public class RequestProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
