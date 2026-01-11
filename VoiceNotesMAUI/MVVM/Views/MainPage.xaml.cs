using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.ViewModels;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();

        _viewModel = new MainViewModel();
        BindingContext = _viewModel;
    }

    private async void OnAgregarNota(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            await btn.ScaleToAsync(1.1, 100);
            await btn.ScaleToAsync(1, 100);
        }

        await Navigation.PushAsync(new AddNotePage(_viewModel));
    }

    private async void OnEliminarNota(object sender, EventArgs e)
    {
        var boton = (Button)sender;
        var nota = boton.CommandParameter as Nota;

        if (nota != null)
        {
            // Esto detendrá la navegación visualmente porque el botón ya consumió el clic
            bool aceptar = await DisplayAlert("Eliminar", "¿Deseas borrar esta nota?", "Sí", "No");
            if (aceptar)
            {
                _viewModel.EliminarNota(nota);
            }
        }
    }


    private async void OnNotaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        var lista = (CollectionView)sender;
        var nota = e.CurrentSelection.FirstOrDefault() as Nota;

        if (nota == null) return;

        // LIMPIAMOS LA SELECCIÓN INMEDIATAMENTE
        // Esto evita que al volver de "detalles" o al borrar se quede marcada
        lista.SelectedItem = null;

        // NAVEGAMOS
        await Navigation.PushAsync(new NoteDetailPage(nota));
    }
}