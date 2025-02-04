using MSFercorp.Seguridad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Seguridad.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);

        bool Validate(string userName, string password);
    }
}
