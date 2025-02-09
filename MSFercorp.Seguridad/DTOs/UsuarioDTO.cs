using System.Collections.Generic;

namespace MSFercorp.Seguridad.DTOs
{
    public class UsuarioDTO
    {
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public List<RolDTO> Roles { get; set; }
    }
}
