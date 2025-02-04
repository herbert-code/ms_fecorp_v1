using MSFercorp.Pago.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Services
{
    public interface IPagoService
    {
        Task<IEnumerable<Models.Pago>> GetAllPagos();
        Task<Models.Pago> GetPago(int id);
        Task CreatePago(Models.Pago pago);
        Task UpdatePago(Models.Pago pago);
        Task DeletePago(int id);
    }
}
