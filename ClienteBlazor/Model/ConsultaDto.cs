namespace ClienteBlazor.Model
{
    public class ConsultaDTO
    {
        public int ConsultaId { get; set; }

        public string Mensaje { get; set; }

        public DateTime FechaHora { get; set; }

        public int UsuarioId { get; set; }

        public int InmuebleId { get; set; }
    }
}
