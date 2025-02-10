using MSFercorp.Venta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> GetAllServicios();
        Task<Servicio> GetServicio(int id);
        Task CreateServicio(Servicio servicio);
        Task UpdateServicio(Servicio servicio);
        Task DeleteServicio(int id);
    }
}
