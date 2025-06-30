using Kenku.Objects.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Kenku.MauiApplication.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ISession _session;

    [ObservableProperty]
    private string textToSpeak;

    public MainViewModel(ISession session)
    {
        _session = session;
        // Example: Initialize property from session
        TextToSpeak = "Hello from Session!"; // Replace with logic as needed
    }
}