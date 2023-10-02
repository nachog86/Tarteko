namespace ClienteBlazor.Model
{
    public enum TipoInmuebleDto
    {
        Casa,
        Departamento
        // otros tipos según necesidad
    }

    public enum EstadoInmuebleDto
    {
        Alquilado,
        Vendido,
        Disponible
        // otros estados según necesidad
    }

    public class InmuebleDto
    {
        public int InmuebleId { get; set; }
        public string Direccion { get; set; }
        public int NumeroHabitaciones { get; set; }
        public int NumeroBaños { get; set; }
        public bool TieneCochera { get; set; }
        public bool TieneAscensor { get; set; }
        public decimal? MetrosCubiertos { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public TipoInmuebleDto TipoInmueble { get; set; }
        public EstadoInmuebleDto Estado { get; set; }
        public decimal? AreaTerreno { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public int PropietarioId { get; set; }
        // Otros campos necesarios para el cliente
    }
}
