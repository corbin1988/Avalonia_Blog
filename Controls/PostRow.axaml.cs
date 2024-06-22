using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia_Blog.Models;

namespace Avalonia_Blog.Controls
{
    public partial class PostRow : UserControl
    {
        public static readonly DirectProperty<PostRow, Post> PostProperty =
            AvaloniaProperty.RegisterDirect<PostRow, Post>(
                nameof(Post),
                o => o.Post,
                (o, v) => o.Post = v);

        private Post _post; 

        public Post Post
        {
            get { return _post; }
            set { SetAndRaise(PostProperty, ref _post, value); }
        }

        public PostRow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}