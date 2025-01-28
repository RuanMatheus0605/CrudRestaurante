using CrudRestaurante.Context;
using CrudRestaurante.Model;
using CrudRestaurante.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace CrudRestaurante.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context) 
        {
          _context = context;
        }

        public async Task<List<ClientModel>> GetAll()
        {
            List<ClientModel> clients = await _context.Clients.ToListAsync();
            return clients ;
        }

        public async Task<ClientModel> GetId(int id)
        {
            ClientModel client = await _context.Clients.FirstOrDefaultAsync(client => client.Id == id);
            return client;
        }

        public async Task<ClientModel> Create(ClientModel newClient)
        {
            _context.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientModel> Edit(RequestClient requestClient, int id)
        {
            throw new NotImplementedException();
        }  
    }
}
