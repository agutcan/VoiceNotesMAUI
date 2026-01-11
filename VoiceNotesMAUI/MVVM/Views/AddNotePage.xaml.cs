using VoiceNotesMAUI.MVVM.ViewModels;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class AddNotePage : ContentPage
{
    private readonly AddNoteViewModel _viewModel;

    public AddNotePage(MainViewModel mainViewModel)
    {
        InitializeComponent();
        _viewModel = new AddNoteViewModel(mainViewModel);
        BindingContext = _viewModel;
    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        await ((Button)sender).ScaleTo(0.9, 80);
        await ((Button)sender).ScaleTo(1, 80);

        _viewModel.GuardarNota();
        await Navigation.PopAsync();
    }
}
