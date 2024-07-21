using System.Collections.ObjectModel;
using Avalonia_Blog.Models;

public interface IPostService
{
    Post CreatePost(string title, string content, string author);
    ObservableCollection<Post> GetPosts();
    Post? GetPost(string postId);
}