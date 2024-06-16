using ReactiveUI;

namespace Avalonia_Blog.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new RoutingState();  

    public MainWindowViewModel()
    {
        Router.Navigate.Execute(new LoginViewModel(this));
    }
}
