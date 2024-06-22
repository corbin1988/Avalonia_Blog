using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia_Blog.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Avalonia_Blog;

sealed class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    [STAThread]
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddCommonServices();

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IPostService, PostService>();
        // Add other services as needed
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
