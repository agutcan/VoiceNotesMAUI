using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Devices; // Proporciona acceso a Text-to-Speech
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels;

// ViewModel de la página de detalle de una nota
// Se encarga de exponer la información de la nota seleccionada
// y de reproducir su contenido mediante Text-to-Speech
public class NoteDetailViewModel : INotifyPropertyChanged
{
    // Campo privado que almacena la nota actual
    private Nota _nota;

    // Propiedad pública de la nota
    // Permite notificar a la vista si la nota cambia
    public Nota Nota
    {
        get => _nota;
        set
        {
            if (_nota != value)
            {
                _nota = value;

                // Notifica que ha cambiado la nota completa
                OnPropertyChanged();

                // Notifica cambios en las propiedades derivadas
                OnPropertyChanged(nameof(TextoNota));
                OnPropertyChanged(nameof(FechaCreacion));
            }
        }
    }

    // Propiedad calculada que expone el texto de la nota
    // Se usa directamente en el binding de la vista
    public string TextoNota => Nota.Texto;

    // Propiedad calculada que expone la fecha de creación
    public DateTime FechaCreacion => Nota.FechaCreacion;

    // Constructor que recibe la nota seleccionada
    // Obliga a que la nota no sea null
    public NoteDetailViewModel(Nota nota)
    {
        // Garantiza que _nota nunca sea null
        _nota = nota ?? throw new ArgumentNullException(nameof(nota));
    }

    // Método asíncrono que reproduce la nota usando Text-to-Speech
    // Se llama al pulsar el botón "Reproducir nota"
    public async Task ReproducirNotaAsync()
    {
        // Evita reproducir texto vacío o nulo
        if (!string.IsNullOrWhiteSpace(Nota.Texto))
        {
            await TextToSpeech.Default.SpeakAsync(Nota.Texto);
        }
    }

    // Evento requerido por INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    // Método que notifica a la vista que una propiedad ha cambiado
    protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
}
