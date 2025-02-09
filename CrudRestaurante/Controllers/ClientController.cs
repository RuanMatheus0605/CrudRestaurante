﻿using CrudRestaurante.Context;
using CrudRestaurante.Model;
using CrudRestaurante.Model.Requests;
using CrudRestaurante.Repositories.Clients;
using CrudRestaurante.Repositories.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IClientRepository _clientRepository;
        public ClientController(AppDbContext context, IClientRepository clientRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ClientModel> clients = await _clientRepository.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ClientModel client = await _clientRepository.GetId(id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestClient request)
        {
            ClientModel newClient = new ClientModel
            {
                Name = request.Name,
                Address = request.Address,
            };
            ClientModel createdClient = await _clientRepository.Create(newClient);
            return Ok(createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] RequestClient request, int id)
        {
            ClientModel clientEdited = await _clientRepository.Edit(request, id);
            return Ok(clientEdited);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _clientRepository.Delete(id);

            if (response == false)
            {
                return NotFound(new { Message = "Cliente não encontrado" });
            }

            return Ok(new { Message = "Cliente removido com sucesso" });
        }
    }
}
