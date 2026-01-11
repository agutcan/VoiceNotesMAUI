namespace VoiceNotesMAUI.MVVM.Models
{
    public class Nota
    {
        public string Texto { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
