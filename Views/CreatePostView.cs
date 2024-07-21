using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia_Blog.ViewModels;
using ReactiveUI;

namespace Avalonia_Blog.Views;
public partial class CreatePostView : ReactiveUserControl<CreatePostViewModel>
{
    public CreatePostView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}