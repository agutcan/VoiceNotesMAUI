using Microsoft.Maui.Controls;
using VoiceNotesMAUI.MVVM.Views;

namespace VoiceNotesMAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // NavigationPage envuelve MainPage
        return new Window(new NavigationPage(new MainPage()));
    }
}
