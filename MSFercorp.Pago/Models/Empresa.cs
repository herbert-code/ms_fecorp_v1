using System;

namespace MSFercorp.Pago.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public int PagoId { get; set; }
        public Pago Pago { get; set; }
        public int OrdenServicioId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string TipoDetalle { get; set; }
        public string MetodoPago { get; set; }
        public string Referencia { get; set; }
        public string EstadoPago { get; set; }


    }
}
