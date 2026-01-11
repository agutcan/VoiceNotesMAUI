using System.ComponentModel;
using System.Runtime.CompilerServices;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels;

public class AddNoteViewModel : INotifyPropertyChanged
{
    private string _textoNota = string.Empty;
    public string TextoNota
    {
        get => _textoNota;
        set
        {
            if (_textoNota != value)
            {
                _textoNota = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LongitudTexto));
            }
        }
    }

    public int LongitudTexto => TextoNota.Length;

    // Crear nueva nota
    public Nota CrearNota()
    {
        return new Nota { Texto = TextoNota, FechaCreacion = DateTime.Now };
    }

    public void Limpiar()
    {
        TextoNota = string.Empty;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
}
