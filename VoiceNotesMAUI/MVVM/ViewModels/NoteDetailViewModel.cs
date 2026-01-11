using Microsoft.Maui.Media;

namespace VoiceNotesMAUI.MVVM.ViewModels
{
    public class NoteDetailViewModel
    {
        public string TextoNota { get; }

        public NoteDetailViewModel(string texto)
        {
            TextoNota = texto;
        }

        public async Task ReproducirAsync()
        {
            await TextToSpeech.Default.SpeakAsync(TextoNota);
        }
    }
}
