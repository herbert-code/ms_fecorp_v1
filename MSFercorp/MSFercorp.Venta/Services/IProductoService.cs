using MSFercorp.Venta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetProducto(int id);
        Task CreateProducto(Producto producto);
        Task UpdateProducto(Producto producto);
        Task DeleteProducto(int id);
    }
}
