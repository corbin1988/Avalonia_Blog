using System.Reactive;
using Avalonia_Blog.ViewModels;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class PostsViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "posts";

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToLogin { get; }

    public ReactiveCommand<string, IRoutableViewModel> GoToPost { get; }

    public PostsViewModel(IScreen screen)
    {
        HostScreen = screen;

        GoToLogin = ReactiveCommand.CreateFromObservable(() => {
            return HostScreen.Router.Navigate.Execute(new LoginViewModel(screen));
        });

        GoToPost = ReactiveCommand.CreateFromObservable<string, IRoutableViewModel>((postId) => {
            return HostScreen.Router.Navigate.Execute(new PostViewModel(screen, postId));
        });
    }
}