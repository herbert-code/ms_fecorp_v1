using MSFercorp.Venta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public interface IAlmecenService
    {
        Task<IEnumerable<Almacen>> GetAllAlamcenes();
        Task<Almacen> GetAlmacen(int id);
        Task CreateAlmacen(Almacen almacen);
        Task UpdateAlmacen(Almacen almacen);
        Task DeleteAlmacen(int id);
    }
}
