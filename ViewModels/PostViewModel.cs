using System.Reactive;
using Avalonia_Blog.ViewModels;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class PostViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "post";

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => HostScreen.Router.NavigateBack;

    public string PostId { get; }

    public PostViewModel(IScreen screen, string postId)
    {
        HostScreen = screen;
        PostId = postId;
    }
}