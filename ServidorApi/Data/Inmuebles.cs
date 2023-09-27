using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServidorApi.Data
{
    public enum TipoInmueble
    {
        Casa,
        Departamento
        // otros tipos según necesidad
    }

    public enum EstadoInmueble
    {
        Alquilado,
        Vendido,
        Disponible
        // otros estados según necesidad
    }

    public class Inmueble
    {
        public int InmuebleId { get; set; }
        
        [Required]
        public string Direccion { get; set; }
        
        [Required]
        public int NumeroHabitaciones { get; set; }
        
        [Required]
        public int NumeroBaños { get; set; }
        
        [Required]
        public bool TieneCochera { get; set; }
        
        [Required]
        public bool TieneAscensor { get; set; }
        
        public decimal? MetrosCubiertos { get; set; }
        
        [Required]
        public string Descripcion { get; set; }
        
        [Required]
        public decimal Precio { get; set; }
        
        [Required]
        public TipoInmueble TipoInmueble { get; set; }
        
        [Required]
        public EstadoInmueble Estado { get; set; }
        
        public decimal? AreaTerreno { get; set; }

        [Required]
        public string Ciudad { get; set; }
        
        [Required]
        public string Provincia { get; set; }
        
        [Required]
        public string CodigoPostal { get; set; }
        
        [Required]
        public string Pais { get; set; }

        public ICollection<Imagen> Imagenes { get; set; } = new List<Imagen>();
        public ICollection<Video> Videos { get; set; } = new List<Video>();

        [Required]
        public int PropietarioId { get; set; }
        public Usuario Propietario { get; set; }

        public ICollection<UsuarioInmueble> UsuarioInmuebles { get; set; } = new List<UsuarioInmueble>();
        public ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
        public ICollection<UsuarioFavorito> UsuariosFavoritos { get; set; } = new List<UsuarioFavorito>();
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}








        



        