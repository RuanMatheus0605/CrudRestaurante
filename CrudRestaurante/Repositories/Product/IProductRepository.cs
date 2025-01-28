using CrudRestaurante.Model;
using CrudRestaurante.Model.Requests;

namespace CrudRestaurante.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetId(int id);
        Task<ProductModel> Create(ProductModel newProduct);
        Task<ProductModel> Edit(RequestProduct requestProduct, int id);
        Task<bool> Delete(int id);

        //public interface IUsuarioRepositorio
        //{
        //    Task<List<UsuarioModel>> BuscarTodosUsuarios();
        //    Task<UsuarioModel> BuscarPorId(int id);
        //    Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        //    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        //    Task<bool> Apagar(int id);
        //    Task Adicionar(object usuario);
        //}
    }
}
