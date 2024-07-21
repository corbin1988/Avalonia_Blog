using System;
using System.Linq;
using System.Reactive;
using Avalonia_Blog.Services;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class CreatePostViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "createpost";

    private readonly IPostService _postService;

    public IScreen HostScreen { get; }

    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string _content = string.Empty;
    public string Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    private string _author = string.Empty;
    public string Author
    {
        get => _author;
        set => this.RaiseAndSetIfChanged(ref _author, value);
    }

    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => HostScreen.Router.NavigateBack;

    public CreatePostViewModel(IScreen screen)
    {
        HostScreen = screen;
        _postService =  Program.ServiceProvider.GetRequiredService<IPostService>();
    }

    public ReactiveCommand<Unit, Unit> CreatePost => ReactiveCommand.Create(() =>
    {
        // Fix: Change the type of newPost to the appropriate type returned by _postService.CreatePost method
        var newPost = _postService.CreatePost(Title, Content, Author);
        HostScreen.Router.NavigateBack.Execute().Subscribe();
        var posts = _postService.GetPosts();
    });
}