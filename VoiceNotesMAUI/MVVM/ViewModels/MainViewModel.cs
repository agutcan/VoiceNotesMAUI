using System.Collections.ObjectModel;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Nota> Notas { get; set; }

        public MainViewModel()
        {
            Notas = new ObservableCollection<Nota>();
        }

        public void AgregarNota(string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto))
            {
                Notas.Add(new Nota { Texto = texto });
            }
        }
    }
}
