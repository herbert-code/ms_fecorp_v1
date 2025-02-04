using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace MSFercorp.Pago.Models
{
    [Table("clientes")]  // Mapea a la tabla 'pagos' en la base de datos
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("persona_id")]
        public int PersonaId { get; set; }

        [Required]
        [Column("pagos_pendientes")]
        public float PagosPendientes { get; set; }
        
    }
}
