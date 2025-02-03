using Microsoft.EntityFrameworkCore;
using MSVenta.Venta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MSVenta.Venta.Repositories;

namespace MSVenta.Venta.Services
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly ContextDatabase _context;

        public DetalleVentaService(ContextDatabase context) => _context = context;

        public async Task<IEnumerable<DetalleVenta>> GetAllDetalles()
            => await _context.DetallesVenta
                .Include(dv => dv.Venta)
                .Include(dv => dv.ProductoAlmacen)
                .ToListAsync();

        public async Task<DetalleVenta> GetDetalle(int id)
            => await _context.DetallesVenta
                .Include(dv => dv.Venta)
                .Include(dv => dv.ProductoAlmacen)
                .FirstOrDefaultAsync(dv => dv.Id == id);

        public async Task CreateDetalle(DetalleVenta detalle)
        {
            // Validar existencia de Venta y ProductoAlmacen
            if (!await _context.Ventas.AnyAsync(v => v.Id == detalle.VentaId))
                throw new Exception("Venta no existe");

            if (!await _context.ProductosAlmacenes.AnyAsync(pa => pa.Id == detalle.ProductoAlmacenId))
                throw new Exception("Producto en almacén no existe");

            await _context.DetallesVenta.AddAsync(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDetalle(DetalleVenta detalle)
        {
            _context.Entry(detalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDetalle(int id)
        {
            var detalle = await _context.DetallesVenta.FindAsync(id);
            _context.DetallesVenta.Remove(detalle);
            await _context.SaveChangesAsync();
        }
    }
}
