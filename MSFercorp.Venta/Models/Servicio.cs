namespace MSFercorp.Venta.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        
        
    }
}
