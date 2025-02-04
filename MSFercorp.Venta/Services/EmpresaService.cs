using Microsoft.EntityFrameworkCore;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public class EmpresaService : IEmpresaService
    {

        private readonly ContextDatabase _context;

        public EmpresaService(ContextDatabase context) => _context = context;

        public async Task CreateEmpresa(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetEmpresa(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task UpdateEmpresa(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
