namespace VoiceNotesMAUI;

public partial class AddNotePage : ContentPage
{
    public AddNotePage()
    {
        InitializeComponent();
    }

    private async void OnGuardarNota(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await btn.ScaleTo(0.95, 50);
        await btn.ScaleTo(1, 50);

        if (!string.IsNullOrWhiteSpace(EntradaNota.Text))
        {
            MainPage.Notas.Add(EntradaNota.Text);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Aviso", "La nota no puede estar vacía", "OK");
        }
    }

}
