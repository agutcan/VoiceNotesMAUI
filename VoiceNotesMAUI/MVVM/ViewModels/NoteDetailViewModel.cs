using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Devices; // Para TextToSpeech
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels;

public class NoteDetailViewModel : INotifyPropertyChanged
{
    private Nota _nota;

    public Nota Nota
    {
        get => _nota;
        set
        {
            if (_nota != value)
            {
                _nota = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TextoNota));
                OnPropertyChanged(nameof(FechaCreacion));
            }
        }
    }

    public string TextoNota => Nota.Texto;
    public DateTime FechaCreacion => Nota.FechaCreacion;

    public NoteDetailViewModel(Nota nota)
    {
        // Garantiza que _nota nunca sea null
        _nota = nota ?? throw new ArgumentNullException(nameof(nota));
    }

    // Método para reproducir la nota mediante Text-to-Speech
    public async Task ReproducirNotaAsync()
    {
        if (!string.IsNullOrWhiteSpace(Nota.Texto))
        {
            await TextToSpeech.Default.SpeakAsync(Nota.Texto);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
}
