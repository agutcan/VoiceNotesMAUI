using VoiceNotesMAUI.MVVM.ViewModels;

namespace VoiceNotesMAUI.MVVM.ViewModels
{
    public class AddNoteViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public string TextoNota { get; set; }

        public AddNoteViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void GuardarNota()
        {
            _mainViewModel.AgregarNota(TextoNota);
        }
    }
}
