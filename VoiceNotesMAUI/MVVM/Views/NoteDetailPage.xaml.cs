using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class NoteDetailPage : ContentPage
{
    // ViewModel que contiene la nota y la lógica de reproducción
    private readonly NoteDetailViewModel _viewModel;

    // Constructor de la página, recibe la nota a mostrar
    public NoteDetailPage(Nota nota)
    {
        // Inicializa los componentes definidos en XAML
        InitializeComponent();

        // Crea el ViewModel con la nota recibida
        _viewModel = new NoteDetailViewModel(nota);

        // Asigna el BindingContext para enlazar la UI con el ViewModel
        BindingContext = _viewModel;
    }

    // Evento del botón "Reproducir nota"
    private async void OnReproducirNota(object sender, EventArgs e)
    {
        // Animación de rebote al pulsar el botón
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        // Llama al método del ViewModel para reproducir la nota mediante Text-to-Speech
        await _viewModel.ReproducirNotaAsync();
    }

    // Evento del botón "Volver" en el header
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        // Navega hacia atrás en la pila de páginas
        await Navigation.PopAsync();
    }
}
