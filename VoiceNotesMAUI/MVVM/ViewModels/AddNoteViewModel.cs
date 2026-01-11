using System.ComponentModel;
using System.Runtime.CompilerServices;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels;

// ViewModel encargado de la lógica de la página AddNotePage
// Implementa INotifyPropertyChanged para permitir el Data Binding con la vista
public class AddNoteViewModel : INotifyPropertyChanged
{
    // Campo privado que almacena el texto de la nota
    // Se inicializa vacío para evitar valores null
    private string _textoNota = string.Empty;

    // Propiedad enlazada a la vista (Editor)
    // Cada vez que cambia, notifica a la interfaz
    public string TextoNota
    {
        get => _textoNota;
        set
        {
            if (_textoNota != value)
            {
                _textoNota = value;

                // Notifica que la propiedad TextoNota ha cambiado
                OnPropertyChanged();

                // Notifica también el cambio de la longitud del texto
                OnPropertyChanged(nameof(LongitudTexto));
            }
        }
    }

    // Propiedad calculada que devuelve el número de caracteres del texto
    // Se usa para mostrar el contador de caracteres en la interfaz
    public int LongitudTexto => TextoNota.Length;

    // Crea una nueva instancia de Nota a partir del texto introducido
    // Se llama al guardar una nota
    public Nota CrearNota()
    {
        return new Nota
        {
            Texto = TextoNota,
            FechaCreacion = DateTime.Now
        };
    }

    // Limpia el contenido del Editor después de guardar la nota
    public void Limpiar()
    {
        TextoNota = string.Empty;
    }

    // Evento necesario para notificar cambios a la vista
    public event PropertyChangedEventHandler? PropertyChanged;

    // Método auxiliar que lanza el evento PropertyChanged
    // CallerMemberName permite no indicar el nombre de la propiedad manualmente
    protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
}
