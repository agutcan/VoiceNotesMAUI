using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class NoteDetailPage : ContentPage
{
    private readonly NoteDetailViewModel _viewModel;

    public NoteDetailPage(Nota nota)
    {
        InitializeComponent();

        _viewModel = new NoteDetailViewModel(nota);
        BindingContext = _viewModel;
    }

    private async void OnReproducirNota(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        await _viewModel.ReproducirNotaAsync();
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
