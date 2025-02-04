using MSFercorp.Seguridad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Seguridad.Services
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> GetAllRoles();
        Task<Rol> GetRolById(int id);
        Task<Rol> CreateRol(Rol rol);
        Task UpdateRol(Rol rol);
        Task DeleteRol(int id);
    }
}
