using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServidorApi.Data
{
    public class UsuarioInmueble
    {
        [Key, Column(Order = 0)]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Key, Column(Order = 1)]
        public int InmuebleId { get; set; }

        [ForeignKey("InmuebleId")]
        public Inmueble Inmueble { get; set; }
    }
}

