using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class AddNotePage : ContentPage
{
    private readonly AddNoteViewModel _viewModel;
    private readonly MainViewModel _mainViewModel;

    public AddNotePage(MainViewModel mainViewModel)
    {
        InitializeComponent();

        _mainViewModel = mainViewModel;
        _viewModel = new AddNoteViewModel();
        BindingContext = _viewModel;
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnGuardarNota(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        if (!string.IsNullOrWhiteSpace(_viewModel.TextoNota))
        {
            var nuevaNota = _viewModel.CrearNota();
            _mainViewModel.AgregarNota(nuevaNota);
            _viewModel.Limpiar();

            await DisplayAlert("¡Éxito!", "La nota se ha guardado.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Atención", "Escribe algo antes de guardar.", "OK");
        }
    }
}
