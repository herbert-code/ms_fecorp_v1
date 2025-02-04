using Microsoft.EntityFrameworkCore;
using MSFercorp.Pago.Models;
using MSFercorp.Pago.Repositories;
//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Services
{
    public class DetallePagoService : IDetallePagoService
    {

        private readonly ContextDatabase _context;

        public DetallePagoService(ContextDatabase context) => _context = context;

        public async Task CreateDetallePago(DetallePago detallepago)
        {
            await _context.DetallePagos.AddAsync(detallepago);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDetallePago(int id)
        {
            var detallepago = await _context.DetallePagos.FindAsync(id);
            _context.DetallePagos.Remove(detallepago);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DetallePago>> GetAllDetallePagos()
        {
            return await _context.DetallePagos
              .Include(v => v.Pago)              
              .ToListAsync();
        }

        public async Task<DetallePago> GetDetallePago(int id)
        {
            return await _context.DetallePagos.FindAsync(id);
        }

        public async Task UpdateDetallePago(DetallePago detallepago)
        {
            _context.Entry(detallepago).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
