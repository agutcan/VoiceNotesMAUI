using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace VoiceNotesMAUI;

public partial class MainPage : ContentPage
{
    // Cambia List a ObservableCollection
    private ObservableCollection<string> notes = new ObservableCollection<string>();

    public MainPage()
    {
        InitializeComponent();
        NotesCollection.ItemsSource = notes;
    }

    private async void OnAddNoteClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNotePage(notes));
    }

    private async void OnNoteSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is string note)
        {
            await Navigation.PushAsync(new NoteDetailPage(note));
            NotesCollection.SelectedItem = null;
        }
    }
}
