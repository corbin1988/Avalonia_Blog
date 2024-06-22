using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia_Blog.Models;

namespace Avalonia_Blog.Services
{
  public class PostService : IPostService
  {
    private ObservableCollection<Post> _posts;

    public PostService()
    {
      _posts = new ObservableCollection<Post>
      {
        new Post("1","First Post", "Hello world!", "Admin", DateTime.UtcNow),
        new Post("2","Second Post", "This is the second post.", "Admin", DateTime.UtcNow),
        new Post("3","Third Post", "Here's another post.", "User1", DateTime.UtcNow),
        new Post("4","Fourth Post", "More content here.", "User2", DateTime.UtcNow),
        new Post("5","Fifth Post", "Keep on posting.", "Admin", DateTime.UtcNow),
        new Post("6","Sixth Post", "Last example post.", "User3", DateTime.UtcNow)
      };
    }

    public Post CreatePost(string title, string content, string author)
    {
      var newPost = new Post(Guid.NewGuid().ToString(), title, content, author, DateTime.UtcNow);
      _posts.Add(newPost);
      return newPost;
    }

    public ObservableCollection<Post> GetPosts()
    {
      return _posts;
    }

    public Post GetPost(string postId)
    {
      return _posts.FirstOrDefault(post => post.PostId == postId);
    }
  }
}