namespace VoiceNotesMAUI.MVVM.Models
{
    // Modelo que representa una nota dentro de la aplicación
    // Forma parte de la capa Model del patrón MVVM
    public class Nota
    {
        // Texto principal de la nota
        // Se inicializa como cadena vacía para evitar valores null
        public string Texto { get; set; } = string.Empty;

        // Fecha y hora de creación de la nota
        // Se asigna automáticamente al momento de crear el objeto
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
