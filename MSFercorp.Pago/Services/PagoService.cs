using Microsoft.EntityFrameworkCore;
using MSFercorp.Pago.Models;
using MSFercorp.Pago.Repositories;
//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Services
{
    public class PagoService : IPagoService
    {

        private readonly ContextDatabase _context;

        public PagoService(ContextDatabase context) => _context = context;

        public async Task CreatePago(Models.Pago pago)
        {
            await _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Pago>> GetAllPagos()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Models.Pago> GetPago(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task UpdatePago(Models.Pago pago)
        {
            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
