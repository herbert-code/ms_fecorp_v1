using MSFercorp.Venta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAllAreas();
        Task<Area> GetArea(int id);
        Task CreateArea(Area area);
        Task UpdateArea(Area area);
        Task DeleteArea(int id);
    }
}
