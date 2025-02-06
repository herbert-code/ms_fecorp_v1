using Microsoft.EntityFrameworkCore;
using MSFercorp.Pago.Models;
using MSFercorp.Pago.Repositories;
//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Services
{
    public class ClienteService : IClienteService
    {

        private readonly ContextDatabase _context;

        public ClienteService(ContextDatabase context) => _context = context;

        public async Task CreateCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
