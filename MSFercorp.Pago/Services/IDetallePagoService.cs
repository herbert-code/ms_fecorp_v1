using MSFercorp.Pago.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Services
{
    public interface IDetallePagoService
    {
        Task<IEnumerable<DetallePago>> GetAllDetallePagos();
        Task<DetallePago> GetDetallePago(int id);
        Task CreateDetallePago(DetallePago detallepago);
        Task UpdateDetallePago(DetallePago detallepago);
        Task DeleteDetallePago(int id);
    }
}
