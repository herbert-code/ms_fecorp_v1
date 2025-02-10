using Microsoft.EntityFrameworkCore;
using MSFercorp.Seguridad.Models;
using MSFercorp.Seguridad.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFercorp.Seguridad.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContextDatabase _context;

        public UsuarioService(ContextDatabase context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();



        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public bool Validate(string userName, string password)
        {
            var list = _context.Usuarios.ToList();
            var access = list.Where(x => x.Username == userName && x.Password == password)
                .FirstOrDefault();
            if (access != null)
                return true;
            return false;
        }
    }
}
