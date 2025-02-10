using MSFercorp.Venta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetCliente(int id);
        Task CreateCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(int id);
    }
}
