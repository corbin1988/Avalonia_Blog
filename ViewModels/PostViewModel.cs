using System.Reactive;
using Avalonia_Blog.ViewModels;
using Avalonia_Blog.Services;
using ReactiveUI;
using Avalonia_Blog.Models;

namespace Avalonia_Blog.ViewModels;
public class PostViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "post";

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => HostScreen.Router.NavigateBack;

    private readonly PostService _postService;

    public Post Post  { get; set; }

    public string PostId { get; }

    public PostViewModel(IScreen screen, string postId)
    {
        HostScreen = screen;
        PostId = postId;
        _postService = new PostService();

        Post = _postService.GetPost(postId)!;
    }
}