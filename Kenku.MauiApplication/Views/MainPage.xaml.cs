using Kenku.MauiApplication.ViewModels;

namespace Kenku.MauiApplication.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}