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

    private async void OnNotaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Nota nota)
        {
            ((CollectionView)sender).SelectedItem = null; // Desmarcar
            await Navigation.PushAsync(new NoteDetailPage(nota));
        }
    }
}
