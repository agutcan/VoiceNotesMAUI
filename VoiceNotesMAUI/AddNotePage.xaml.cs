using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace VoiceNotesMAUI;

public partial class AddNotePage : ContentPage
{
    private ObservableCollection<string> notes;

    public AddNotePage(ObservableCollection<string> notesList)
    {
        InitializeComponent();
        notes = notesList;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NoteEntry.Text))
        {
            // Esto ahora actualizará automáticamente el CollectionView
            notes.Add(NoteEntry.Text);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "La nota no puede estar vacía.", "OK");
        }
    }
}
