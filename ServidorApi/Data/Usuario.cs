using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServidorApi.Data
{
    public enum Rol
    {
        Propietario,
        Comercial,
        Admin
    }

    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        
        [Required]
        public Rol Rol { get; set; }
        
        // Propiedades de navegación
        public ICollection<Inmueble> InmueblesPropios { get; set; } = new List<Inmueble>();
        public ICollection<UsuarioInmueble> UsuarioInmuebles { get; set; } = new List<UsuarioInmueble>();
    }
}


