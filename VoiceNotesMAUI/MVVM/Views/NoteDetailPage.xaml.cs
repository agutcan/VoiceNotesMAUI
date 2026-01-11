using VoiceNotesMAUI.MVVM.ViewModels;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class NoteDetailPage : ContentPage
{
    private readonly NoteDetailViewModel _viewModel;

    public NoteDetailPage(string texto)
    {
        InitializeComponent();
        _viewModel = new NoteDetailViewModel(texto);
        BindingContext = _viewModel;
    }

    private async void Reproducir_Clicked(object sender, EventArgs e)
    {
        await ((Button)sender).ScaleTo(0.9, 80);
        await ((Button)sender).ScaleTo(1, 80);

        await _viewModel.ReproducirAsync();
    }
}
