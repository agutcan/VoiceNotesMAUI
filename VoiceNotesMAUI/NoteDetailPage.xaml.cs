using Microsoft.Maui.Controls;
namespace VoiceNotesMAUI;

public partial class NoteDetailPage : ContentPage
{
    private string note;

    public NoteDetailPage(string noteText)
    {
        InitializeComponent();
        note = noteText;
        NoteLabel.Text = note;
    }

    private async void OnPlayNoteClicked(object sender, EventArgs e)
    {
        await TextToSpeech.Default.SpeakAsync(note);
    }
}
