using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public interface IUsuarioService
    {
        Task<bool> ValidateUsuario(int usuario_id);
    }
}
