using System.Collections.Generic;

namespace MSFercorp.Venta.DTOs
{
    public class AlmacenConProductosDto
    {
        public int AlmacenId { get; set; }
        public string AlmacenNombre { get; set; }
        public List<ProductoDto> Productos { get; set; }
    }
}
