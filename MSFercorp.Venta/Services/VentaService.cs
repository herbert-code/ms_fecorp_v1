using Microsoft.EntityFrameworkCore;
using MSFercorp.Venta.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public class VentaService : IVentaService
    {
        private readonly ContextDatabase _context;

        public VentaService(ContextDatabase context) => _context = context;

        public async Task<IEnumerable<Models.Venta>> GetAllVentas()
        {
            return await _context.Ventas
                .Include(v => v.Cliente) 
                .ToListAsync();
        }

        public async Task<Models.Venta> GetVenta(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task CreateVenta(Models.Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVenta(Models.Venta venta)
        {
            _context.Entry(venta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
        }
    }
}
