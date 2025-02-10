using Microsoft.EntityFrameworkCore;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public class AreaService : IAreaService
    {

        private readonly ContextDatabase _context;

        public AreaService(ContextDatabase context) => _context = context;

        public async Task CreateArea(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area> GetArea(int id)
        {
            return await _context.Areas.FindAsync(id);
        }

        public async Task UpdateArea(Area area)
        {
            _context.Entry(area).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
