using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

// Página para añadir una nueva nota
// Conecta la interfaz XAML con los ViewModels
public partial class AddNotePage : ContentPage
{
    // ViewModel encargado de manejar la lógica de creación de la nota
    private readonly AddNoteViewModel _viewModel;

    // ViewModel principal donde se almacena la lista completa de notas
    private readonly MainViewModel _mainViewModel;

    // Constructor de la página
    // Recibe el MainViewModel para poder añadir nuevas notas a la lista principal
    public AddNotePage(MainViewModel mainViewModel)
    {
        // Inicializa los componentes definidos en XAML
        InitializeComponent();

        // Guarda la referencia al ViewModel principal
        _mainViewModel = mainViewModel;

        // Crea el ViewModel específico para esta página
        _viewModel = new AddNoteViewModel();

        // Asigna el BindingContext para enlazar la vista con el ViewModel
        BindingContext = _viewModel;
    }

    // Evento del botón "volver"
    // Vuelve a la página anterior en la pila de navegación
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Evento del botón "Guardar Nota"
    // Valida el texto, crea la nota y la añade al ViewModel principal
    private async void OnGuardarNota(object sender, EventArgs e)
    {
        // Animación de rebote del botón al pulsar
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        // Comprueba que el editor no esté vacío
        if (!string.IsNullOrWhiteSpace(_viewModel.TextoNota))
        {
            // Crea la nueva nota usando el ViewModel
            var nuevaNota = _viewModel.CrearNota();

            // Añade la nota al ViewModel principal
            _mainViewModel.AgregarNota(nuevaNota);

            // Limpia el editor para la siguiente nota
            _viewModel.Limpiar();

            // Muestra un mensaje de éxito
            await DisplayAlert("¡Éxito!", "La nota se ha guardado.", "OK");

            // Regresa a la pantalla anterior
            await Navigation.PopAsync();
        }
        else
        {
            // Muestra alerta si el usuario intenta guardar una nota vacía
            await DisplayAlert("Atención", "Escribe algo antes de guardar.", "OK");
        }
    }
}
