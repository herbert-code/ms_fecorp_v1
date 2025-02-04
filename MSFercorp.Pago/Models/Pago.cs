using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace MSFercorp.Pago.Models
{
    [Table("pagos")]  // Mapea a la tabla 'pagos' en la base de datos
    public class Pago
    {
        [Key]
        [Column("id")]
        public int IdPago { get; set; }

        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]        
        [Column("fecha")]
        public DateTime Fecha { get; set; }


        [Required]
        [Column("total")]
        public float Total { get; set; }
        
    }
}
