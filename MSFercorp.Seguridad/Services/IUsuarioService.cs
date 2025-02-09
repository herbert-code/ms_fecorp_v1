using MSFercorp.Seguridad.DTOs;
using MSFercorp.Seguridad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Seguridad.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllUsuarios();        
        Task<UsuarioDTO> GetUsuarioById(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        Usuario Validate(string userName, string password);
        //bool Validate(string userName, string password);
    }
}
