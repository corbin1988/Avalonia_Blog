using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using Avalonia_Blog.Models;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels;
public class PostsViewModel : ViewModelBase, IRoutableViewModel
{
    private readonly IPostService _postService;
    public ObservableCollection<PostRowViewModel> Posts { get; }

    public string? UrlPathSegment => "posts";

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToLogin { get; }
    public ReactiveCommand<string, IRoutableViewModel> GoToPost { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToCreatePost { get; }

    public PostsViewModel(IScreen screen)
    {
        HostScreen = screen;

        _postService = Program.ServiceProvider.GetRequiredService<IPostService>();

        Posts = new ObservableCollection<PostRowViewModel>(_postService.GetPosts().Select(p => new PostRowViewModel(p, screen) { PostId = p.PostId, Title = p.Title }));

        _postService.GetPosts().CollectionChanged += OnPostsChanged;

        GoToLogin = ReactiveCommand.CreateFromObservable(() =>
        {
            return HostScreen.Router.Navigate.Execute(new LoginViewModel(screen));
        });

        GoToPost = ReactiveCommand.CreateFromObservable<string, IRoutableViewModel>((postId) =>
        {
            return HostScreen.Router.Navigate.Execute(new PostViewModel(screen, postId));
        });

        GoToCreatePost = ReactiveCommand.CreateFromObservable(() =>
        {
            return HostScreen.Router.Navigate.Execute(new CreatePostViewModel(screen));
        });
    }


    //I don't get this? Why not just use the service to get the posts?
    private void OnPostsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Post newItem in e.NewItems)
            {
                Posts.Add(new PostRowViewModel(newItem, HostScreen) { PostId = newItem.PostId, Title = newItem.Title });
            }
        }

        if (e.OldItems != null)
        {
            foreach (Post oldItem in e.OldItems)
            {
                var postToRemove = Posts.First(p => p.PostId == oldItem.PostId);
                Posts.Remove(postToRemove);
            }
        }
    }
}