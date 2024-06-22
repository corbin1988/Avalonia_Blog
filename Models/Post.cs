using System;

namespace Avalonia_Blog.Models;
public class Post
{
    public string PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }

    public Post(string postId, string title, string content, string author, DateTime date)
    {
        PostId = postId;
        Title = title;
        Content = content;
        Author = author;
        Date = date;
    }
}