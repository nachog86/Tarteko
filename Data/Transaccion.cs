using System;
using System.ComponentModel.DataAnnotations;

namespace ServidorApi.Data
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        
        [Required]
        public DateTime FechaHora { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        [Required]
        public int InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; }
    }
}
