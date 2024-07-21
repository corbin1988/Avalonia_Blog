I have a PostService:

```csharp
namespace Avalonia_Blog.Services
{
  public class PostService
  {
    private List<Post> _posts;

    public PostService()
    {
      _posts = new List<Post>
      {
        new Post("1","First Post", "Hello world!", "Admin", DateTime.UtcNow),
        new Post("2","Second Post", "This is the second post.", "Admin", DateTime.UtcNow),
        new Post("3","Third Post", "Here's another post.", "User1", DateTime.UtcNow),
        new Post("4","Fourth Post", "More content here.", "User2", DateTime.UtcNow),
        new Post("5","Fifth Post", "Keep on posting.", "Admin", DateTime.UtcNow),
        new Post("6","Sixth Post", "Last example post.", "User3", DateTime.UtcNow)
      };
    }

    public void CreatePost(string title, string content, string author)
    {
      _posts.Add(new Post(Guid.NewGuid().ToString(), title, content, author, DateTime.UtcNow));
    }
    
    public List<Post> GetPosts()
    {
      return _posts;
    }

    public Post? GetPost(string postId)
    {
      return _posts.FirstOrDefault(post => post.PostId == postId);
    }
  }
}
```

What I'm trying to do is to create a new post and add it to the list of posts. I have a CreatePost method that takes in the title, content, and author of the post. 

In my CreatePostViewModel I invoke the CreatePostService here:

```csharp
public class CreatePostViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "createpost";

    private readonly PostService _postService = new PostService();

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
    }

    public ReactiveCommand<Unit, Unit> CreatePost => ReactiveCommand.Create(() =>
    {
        _postService.CreatePost(Title, Content, Author);
        HostScreen.Router.NavigateBack.Execute().Subscribe();
        var posts = _postService.GetPosts(); 
    });
}
```

The `Console.WriteLine(post.Title);` consoles the appropriate titles and shows that the post has been added to the list of posts in the service.

The problem I'm having is the PostsViewModel and PostsView aren't updating:

```csharp
public class PostsViewModel : ViewModelBase, IRoutableViewModel
{
    private readonly PostService _postService;
    public ObservableCollection<PostRowViewModel> Posts { get; }

    public string? UrlPathSegment => "posts";

    public IScreen HostScreen { get; }

    

    public PostsViewModel(IScreen screen)
    {
        HostScreen = screen;

        _postService = new PostService();

        Posts = new ObservableCollection<PostRowViewModel>(_postService.GetPosts().Select(p => new PostRowViewModel(p, screen) { PostId = p.PostId, Title = p.Title }));

    }
}
```



