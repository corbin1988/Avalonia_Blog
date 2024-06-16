using System;
using System.Reactive;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class LoginViewModel : ViewModelBase, IRoutableViewModel
{
  public string? UrlPathSegment => "login";

  public IScreen HostScreen { get; }

  public ReactiveCommand<Unit, IRoutableViewModel> GoToRegister { get; }

  public ReactiveCommand<Unit, IRoutableViewModel> GoToPosts { get; }
  public LoginViewModel(IScreen screen)
  {
    HostScreen = screen;

    GoToRegister = ReactiveCommand.CreateFromObservable(() => {
      return HostScreen.Router.Navigate.Execute(new RegisterViewModel(screen));
    });

    GoToRegister.ThrownExceptions.Subscribe((Exception ex) => {
      Console.WriteLine($"An error occurred: {ex}");
    });

    GoToPosts = ReactiveCommand.CreateFromObservable(() => {
      return HostScreen.Router.Navigate.Execute(new PostsViewModel(screen));
    });
  }
}