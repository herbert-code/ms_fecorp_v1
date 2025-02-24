﻿using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSVenta.Seguridad.Models
{
    public class Rol
    {
        [Key]
        [Column("ID_Rol")]
        public int ID_Rol { get; set; }
        public string Nombre_Rol { get; set; }
        public string Descripción { get; set; }
        public DateTime Fecha_Creación { get; set; }
        // Relaciones
        public ICollection<RolPermiso> RolPermisos { get; set; }
    }
}
