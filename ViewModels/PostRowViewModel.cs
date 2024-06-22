using System;
using System.Reactive;
using Avalonia_Blog.Models;
using ReactiveUI;

namespace Avalonia_Blog.ViewModels
{
    public class PostRowViewModel : ReactiveObject
    {
        private string _title;
        private string _postId;

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string PostId
        {
            get => _postId;
            set => this.RaiseAndSetIfChanged(ref _postId, value);
        }

        public IScreen HostScreen { get; }

        public ReactiveCommand<string, IRoutableViewModel> GoToPost { get; }

        public PostRowViewModel(Post post, IScreen screen)
        {
            HostScreen = screen;
            Title = post.Title;
            PostId = post.PostId;

            GoToPost = ReactiveCommand.CreateFromObservable<string, IRoutableViewModel>((postId) =>
            {
                return HostScreen.Router.Navigate.Execute(new PostViewModel(screen, postId));
            });
        }
    }
}