namespace ClienteBlazor.Model
{
    // Acción 1: Crear la clase DTO para Usuario
    public class UsuarioDTO
    {
        // Acción 2: Agregar las propiedades básicas que queremos exponer al cliente. 
        // No necesitamos exponer todo si hay campos que preferimos mantener internos o privados.

        public int UsuarioId { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Rol { get; set; }

        // Acción 3: Decidir qué hacer con las relaciones
        // Por ahora, solo se proporcionan los ID de los inmuebles relacionados para no sobrecargar el DTO. 
        // En una aplicación real, podrías decidir cargar más detalles o mantenerlo simple como se muestra aquí.

        public ICollection<int> InmueblesPropiosIds { get; set; } = new List<int>();
    }
}
