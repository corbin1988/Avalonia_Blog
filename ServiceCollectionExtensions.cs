using Microsoft.Extensions.DependencyInjection;
using Avalonia_Blog.Services;
using Avalonia_Blog.ViewModels;

namespace Avalonia_Blog
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<IPostService, PostService>();
            services.AddTransient<MainWindowViewModel>();
            // Add other services and ViewModels as needed
        }
    }
}