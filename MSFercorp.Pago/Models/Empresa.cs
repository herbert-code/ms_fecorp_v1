using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSFercorp.Pago.Models
{
    public class Empresa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nit")]
        public string Nit { get; set; }
        [Column("razon_social")]
        public string RazonSocial { get; set; }
        [Column("email")] 
        public string Email { get; set; }
        [Column("telefono")]
        public string Telefono { get; set; }
        [Column("nro_patronal")]
        public string NroPatronal { get; set; }
        [ForeignKey("Cliente")]
        [Column("cliente_id")] 
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Column("tipo_empresa")]
        public string TipoEmpresa { get; set; }
        [Column("tipo_sociedad")]
        public string TipoSociedad { get; set; }


    }
}
