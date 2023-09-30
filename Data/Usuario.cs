using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServidorApi.Data
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        public string Auth0UserId { get; set; } // Almacenar el identificador de usuario de Auth0

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Rol { get; set; } // Propietario, Consumidor, Comercial, Admin

        // Propiedades de navegación
        public ICollection<Inmueble> InmueblesPropios { get; set; } = new List<Inmueble>();
        public ICollection<UsuarioInmueble> UsuarioInmuebles { get; set; } = new List<UsuarioInmueble>();
    }
}

