using VoiceNotesMAUI.MVVM.ViewModels;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainViewModel ViewModel { get; }

    public MainPage()
    {
        InitializeComponent();
        ViewModel = new MainViewModel();
        BindingContext = ViewModel;
    }

    private async void AgregarNota_Clicked(object sender, EventArgs e)
    {
        await ((Button)sender).ScaleTo(0.9, 80);
        await ((Button)sender).ScaleTo(1, 80);

        await Navigation.PushAsync(new AddNotePage(ViewModel));
    }
}
