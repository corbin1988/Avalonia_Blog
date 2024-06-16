using Avalonia;
using Avalonia.Controls;

namespace Avalonia_Blog.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // This project will never be in prod,
        // so we can safely attach the dev tools.
        this.AttachDevTools();
    }
}