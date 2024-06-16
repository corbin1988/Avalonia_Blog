using System.Reactive;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class RegisterViewModel : ViewModelBase, IRoutableViewModel

{
  public string? UrlPathSegment => "register";

  public ReactiveCommand<Unit, IRoutableViewModel> GoToLogin { get; }


  public IScreen HostScreen { get; }

  public RegisterViewModel(IScreen screen)
  {
    HostScreen = screen;

    GoToLogin = ReactiveCommand.CreateFromObservable(() => {
      return HostScreen.Router.Navigate.Execute(new LoginViewModel(screen));
    });
  }
}