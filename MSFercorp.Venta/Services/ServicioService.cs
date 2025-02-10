using Microsoft.EntityFrameworkCore;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public class ServicioService : IServicioService
    {
        private readonly ContextDatabase _context;

        public ServicioService(ContextDatabase context) => _context = context;

        public async Task<IEnumerable<Servicio>> GetAllServicios()
        {            
            return await _context.Servicios
                .Include(v => v.Area)
                .ToListAsync();            
        } 

        public async Task<Servicio> GetServicio(int id)
        {
            return await _context.Servicios
               .Include(v => v.Area)
               .FirstOrDefaultAsync(v => v.Id == id);
        }           

        public async Task CreateServicio(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServicio(Servicio servicio)
        {
            _context.Entry(servicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }
    }
}
