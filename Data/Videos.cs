namespace ServidorApi.Data
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public int InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; }
    }
}
