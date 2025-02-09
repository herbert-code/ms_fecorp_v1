using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations; // Añade este using


namespace MSFercorp.Seguridad.Models
{
    public class Permiso
    {
        [Key]
        public int ID_Permiso { get; set; }
        public string Nombre_Permiso { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public ICollection<RolPermiso> RolPermisos { get; set; }
    }
}
