using CrudRestaurante.Model.Requests;
using CrudRestaurante.Model;

namespace CrudRestaurante.Repositories.Clients
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> GetAll();
        Task<ClientModel> GetId(int id);
        Task<ClientModel> Create(ClientModel newClient);
        Task<ClientModel> Edit(RequestClient requestClient, int id);
        Task<bool> Delete(int id);
    }
}
