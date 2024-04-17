namespace HrAnalyzer.Helpers;

public static class ServiceLocator
{
    private static IServiceProvider ServiceProvider { get; set; }

    public static void Initialize(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public static T GetService<T>() => ServiceProvider.GetService<T>();
}