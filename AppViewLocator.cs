using System;
using Avalonia_Blog.ViewModels;
using Avalonia_Blog.Views;
using ReactiveUI;

namespace Avalonia_Blog;

public class AppViewLocator : ReactiveUI.IViewLocator
{
  public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch
  {
    LoginViewModel context => new LoginView { DataContext = context },
    RegisterViewModel context => new RegisterView { DataContext = context },
    PostsViewModel context => new PostsView { DataContext = context },
    PostViewModel context => new PostView { DataContext = context },
    CreatePostViewModel context => new CreatePostView { DataContext = context },
    _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
  };
}