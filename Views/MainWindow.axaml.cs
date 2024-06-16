using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia_Blog.ViewModels;
using ReactiveUI;

namespace Avalonia_Blog.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {        
        // This project will never be in prod,
        // so we can safely attach the dev tools.
        this.AttachDevTools();

        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}