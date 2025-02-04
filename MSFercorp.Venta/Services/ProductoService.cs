using Microsoft.EntityFrameworkCore;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ContextDatabase _context;

        public ProductoService(ContextDatabase context) => _context = context;

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {            
            return await _context.Productos
                .Include(v => v.Categoria)
                .ToListAsync();            
        } 

        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Productos
               .Include(v => v.Categoria)
               .FirstOrDefaultAsync(v => v.Id == id);
        }           

        public async Task CreateProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }
}
