
namespace VoiceNotesMAUI;

public partial class NoteDetailPage : ContentPage
{
    private string notaTexto;

    public NoteDetailPage(string nota)
    {
        InitializeComponent();
        notaTexto = nota;
        EtiquetaNota.Text = nota;
    }

    private async void OnReproducirNota(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await btn.ScaleTo(0.95, 50);
        await btn.ScaleTo(1, 50);

        await TextToSpeech.Default.SpeakAsync(notaTexto);
    }

}
