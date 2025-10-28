namespace Whistler.Application.FunctionalTests;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Whistler.Application;
using Whistler.Infrastructure;

public abstract class TestBase
{
    protected ServiceProvider Provider { get; private init; }

    public TestBase()
    {
        var services = new ServiceCollection();

        var collection = new Dictionary<string, string?>
        {
            { "" , " " },
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(collection)
            .Build();

        services.AddApplication();
        services.AddInfrastructure(configuration);

        this.Provider = services.BuildServiceProvider();
    }
}
