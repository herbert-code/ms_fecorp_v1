using MSFercorp.Pago.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSFercorp.Pago.Models
{
    [Table("detalle_pagos")]
    public class DetallePago
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("pago_id")]
        public int PagoId { get; set; }        
        public Pago Pago { get; set; }
        [Column("orden_servicio_id")]
        public int OrdenServicioId { get; set; }
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("monto")]
        public double Monto { get; set; }
        [Column("tipo_detalle")]
        public string TipoDetalle { get; set; }
        [Column("metodo_pago")]
        public string MetodoPago { get; set; }
        [Column("referencia")]
        public string Referencia { get; set; }
        [Column("estado_pago")]
        public string EstadoPago { get; set; }


    }
}
