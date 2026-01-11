using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.Views;

namespace VoiceNotesMAUI;

public partial class App : Application
{
    // Constructor de la aplicación
    // Inicializa los recursos, estilos y colores definidos en App.xaml
    public App()
    {
        InitializeComponent(); // Carga todos los recursos definidos en XAML
    }

    // Crea la ventana principal de la aplicación
    // Envuelve la MainPage en un NavigationPage para habilitar la navegación PushAsync/PopAsync
    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Devuelve la ventana principal con la página inicial dentro de un NavigationPage
        return new Window(new NavigationPage(new MainPage()));
    }
}
