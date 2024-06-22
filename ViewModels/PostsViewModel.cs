using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia_Blog.Models;
using Avalonia_Blog.Services;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class PostsViewModel : ViewModelBase, IRoutableViewModel
{
    private readonly PostService _postService;
    public ObservableCollection<PostRowViewModel> Posts { get; }

    public string? UrlPathSegment => "posts";

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToLogin { get; }

    public ReactiveCommand<string, IRoutableViewModel> GoToPost { get; }

    public PostsViewModel(IScreen screen)
    {
        HostScreen = screen;

        _postService = new PostService();

        Posts = new ObservableCollection<PostRowViewModel>(_postService.GetPosts().Select(p => new PostRowViewModel(p, screen) { PostId = p.PostId, Title = p.Title }));

        GoToLogin = ReactiveCommand.CreateFromObservable(() =>
        {
            return HostScreen.Router.Navigate.Execute(new LoginViewModel(screen));
        });

        GoToPost = ReactiveCommand.CreateFromObservable<string, IRoutableViewModel>((postId) =>
        {
            return HostScreen.Router.Navigate.Execute(new PostViewModel(screen, postId));
        });
    }
}