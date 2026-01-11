using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class MainPage : ContentPage
{
    // ViewModel principal que contiene la lista de notas y lógica de filtrado/eliminación
    private readonly MainViewModel _viewModel;

    // Constructor de la página
    public MainPage()
    {
        InitializeComponent(); // Inicializa los componentes XAML

        _viewModel = new MainViewModel(); // Crea instancia del ViewModel
        BindingContext = _viewModel; // Asocia la página al ViewModel para binding
    }

    // Evento del botón "Agregar nota"
    // Abre la página AddNotePage pasando el ViewModel principal
    private async void OnAgregarNota(object sender, EventArgs e)
    {
        // Animación de rebote al pulsar el botón
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        // Navega a la página de creación de nota
        await Navigation.PushAsync(new AddNotePage(_viewModel));
    }

    // Evento del botón "Eliminar nota" en cada tarjeta
    private async void OnEliminarNota(object sender, EventArgs e)
    {
        var boton = (Button)sender;
        var nota = boton.CommandParameter as Nota;

        if (nota != null)
        {
            // Pregunta al usuario si desea eliminar la nota
            bool aceptar = await DisplayAlert("Eliminar", "¿Deseas borrar esta nota?", "Sí", "No");
            if (aceptar)
            {
                _viewModel.EliminarNota(nota); // Elimina la nota del ViewModel
            }
        }
    }

    // Evento cuando se selecciona una nota en la CollectionView
    private async void OnNotaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        var lista = (CollectionView)sender;
        var nota = e.CurrentSelection.FirstOrDefault() as Nota;

        if (nota == null) return;

        // Limpia la selección inmediatamente para evitar que quede marcada
        lista.SelectedItem = null;

        // Navega a la página de detalles de la nota
        await Navigation.PushAsync(new NoteDetailPage(nota));
    }
}
