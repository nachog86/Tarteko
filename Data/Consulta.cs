using System;

namespace ServidorApi.Data
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; }
    }
}

