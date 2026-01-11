using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VoiceNotesMAUI.MVVM.Models;

namespace VoiceNotesMAUI.MVVM.ViewModels
{
    // ViewModel principal de la aplicación
    // Controla la lista de notas, el filtrado y las acciones de agregar/eliminar
    public class MainViewModel : INotifyPropertyChanged
    {
        // Colección observable de notas
        // ObservableCollection notifica automáticamente a la vista
        // cuando se añaden o eliminan elementos
        public ObservableCollection<Nota> Notas { get; set; } = new();

        // Texto introducido en el SearchBar
        private string _filtroTexto = string.Empty;

        // Indica si NO hay notas tras aplicar el filtro
        // Se usa para mostrar un mensaje de "No encontramos notas"
        public bool SinNotasFiltradas => NotasFiltradas.Count == 0;

        // Propiedad enlazada al SearchBar
        // Cada vez que cambia, recalcula la lista filtrada
        public string FiltroTexto
        {
            get => _filtroTexto;
            set
            {
                if (_filtroTexto != value)
                {
                    _filtroTexto = value;

                    // Notifica que ha cambiado el texto del filtro
                    OnPropertyChanged();

                    // Notifica que debe recalcularse la lista filtrada
                    OnPropertyChanged(nameof(NotasFiltradas));

                    // Notifica si hay o no resultados tras el filtrado
                    OnPropertyChanged(nameof(SinNotasFiltradas));
                }
            }
        }

        // Propiedad calculada que devuelve las notas filtradas
        // según el texto introducido en el SearchBar
        public ObservableCollection<Nota> NotasFiltradas
        {
            get
            {
                // Si no hay texto de filtro, se devuelven todas las notas
                if (string.IsNullOrWhiteSpace(FiltroTexto))
                    return Notas;

                // Filtra las notas ignorando mayúsculas/minúsculas
                var filtradas = Notas
                    .Where(n => n.Texto.Contains(FiltroTexto, StringComparison.OrdinalIgnoreCase));

                // Se devuelve una nueva colección para que la vista se actualice
                return new ObservableCollection<Nota>(filtradas);
            }
        }

        // Indica si no hay ninguna nota en la colección principal
        // (independientemente del filtro)
        public bool SinNotas => Notas.Count == 0;

        // Agrega una nueva nota a la colección
        public void AgregarNota(Nota nota)
        {
            Notas.Add(nota);

            // Se notifica para refrescar la lista y los mensajes visuales
            OnPropertyChanged(nameof(NotasFiltradas));
            OnPropertyChanged(nameof(SinNotasFiltradas));
        }

        // Elimina una nota existente
        public void EliminarNota(Nota nota)
        {
            if (Notas.Contains(nota))
            {
                Notas.Remove(nota);

                // Se actualiza la vista tras eliminar
                OnPropertyChanged(nameof(NotasFiltradas));
                OnPropertyChanged(nameof(SinNotasFiltradas));
            }
        }

        // Evento requerido por INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método que lanza el evento para notificar cambios a la interfaz
        protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
