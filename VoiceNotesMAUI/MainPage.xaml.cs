using System.Collections.ObjectModel;

namespace VoiceNotesMAUI;

public partial class MainPage : ContentPage
{
    public static ObservableCollection<string> Notas { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        ColeccionNotas.ItemsSource = Notas;
    }

    private async void OnAgregarNota(object sender, EventArgs e)
    {
        var btn = sender as Button;
        // animación rebote
        await btn.ScaleTo(0.95, 50);
        await btn.ScaleTo(1, 50);

        await Navigation.PushAsync(new AddNotePage());
    }


    private async void OnNotaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is string nota)
        {
            await Navigation.PushAsync(new NoteDetailPage(nota));
            ColeccionNotas.SelectedItem = null;
        }
    }
}


