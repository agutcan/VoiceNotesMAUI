using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();

        _viewModel = new MainViewModel();
        BindingContext = _viewModel;
    }

    private async void OnAgregarNota(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        await Navigation.PushAsync(new AddNotePage(_viewModel));
    }

    private async void OnEliminarNota(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is Nota nota)
        {
            // Opcional: pedir confirmación antes de eliminar
            bool confirmar = await DisplayAlert("Confirmar", "¿Eliminar esta nota?", "Sí", "No");
            if (confirmar)
            {
                _viewModel.EliminarNota(nota);
            }
        }
    }


    private async void OnNotaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Nota nota)
        {
            ((CollectionView)sender).SelectedItem = null; // Desmarcar
            await Navigation.PushAsync(new NoteDetailPage(nota));
        }
    }
}
