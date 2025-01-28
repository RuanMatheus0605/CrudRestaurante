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

        public async Task<bool> Delete(int id)
        {
            ClientModel clientExist = await GetId(id);

            if (clientExist == null)
            {
                return false;
            }

            _context.Clients.Remove(clientExist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ClientModel> Edit(RequestClient requestClient, int id)
        {
            ClientModel clientExist = await GetId(id);

            if (clientExist == null)
            {
                throw new Exception($"Cliente do ID: {id} não foi encontrado no banco de dados.");
            }

            clientExist.Name = requestClient.Name;
            clientExist.Address = requestClient.Address;

            _context.Clients.Update(clientExist);
            await _context.SaveChangesAsync();

            return clientExist;
        }  
    }
}
