using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia_Blog.ViewModels;
using ReactiveUI;

namespace Avalonia_Blog.Views;
public partial class PostView : ReactiveUserControl<PostViewModel>
{
  public PostView()
  {
    this.WhenActivated(disposables => { });
    AvaloniaXamlLoader.Load(this);
  }
}