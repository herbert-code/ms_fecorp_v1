using MSFercorp.Pago.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Services
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetAllEmpresas();
        Task<Empresa> GetEmpresa(int id);
        Task CreateEmpresa(Empresa empresa);
        Task UpdateEmpresa(Empresa empresa);
        Task DeleteEmpresa(int id);
    }
}
