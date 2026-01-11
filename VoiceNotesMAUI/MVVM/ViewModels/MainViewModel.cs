using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Nota> Notas { get; set; } = new();

        private string _filtroTexto = string.Empty;
        public string FiltroTexto
        {
            get => _filtroTexto;
            set
            {
                if (_filtroTexto != value)
                {
                    _filtroTexto = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NotasFiltradas));
                }
            }
        }

        // Propiedad filtrada para la lista
        public ObservableCollection<Nota> NotasFiltradas
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FiltroTexto))
                    return Notas;

                var filtradas = Notas
                    .Where(n => n.Texto.Contains(FiltroTexto, StringComparison.OrdinalIgnoreCase));

                return new ObservableCollection<Nota>(filtradas);
            }
        }

        // ✅ Nueva propiedad para saber si no hay notas
        public bool SinNotas => Notas.Count == 0;

        public void AgregarNota(Nota nota)
        {
            Notas.Add(nota);
            OnPropertyChanged(nameof(NotasFiltradas));
            OnPropertyChanged(nameof(SinNotas)); // Actualiza el binding
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
