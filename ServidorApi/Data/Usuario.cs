using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

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
       public string PasswordHash { get; set; } // Almacena el hash, no la contraseña original
        public string Email { get; set; }
        
        [Required]
        public Rol Rol { get; set; }
        
        // Propiedades de navegación
        public ICollection<Inmueble> InmueblesPropios { get; set; } = new List<Inmueble>();
        public ICollection<UsuarioInmueble> UsuarioInmuebles { get; set; } = new List<UsuarioInmueble>();

       public void SetPassword(string password)
{
    if (string.IsNullOrEmpty(password))
    {
        throw new ArgumentNullException(nameof(password), "Password cannot be null or empty.");
    }
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
}

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}

