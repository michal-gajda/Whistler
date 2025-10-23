namespace Whistler.WebApi;

using System.Diagnostics;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

public static class ServiceExtensions
{
    public static IServiceCollection AddObservability(this IServiceCollection services, string serviceName, string serviceNamespace, string serviceVersion = "1.0.0")
    {
        var attributes = new Dictionary<string, object>
        {
            ["environment.name"] = "docker",
            ["team.name"] = "dev",
        };

        var resourceBuilder = ResourceBuilder
            .CreateDefault()
            .AddService(serviceName: serviceName, serviceNamespace: serviceNamespace, serviceVersion: serviceVersion)
            .AddAttributes(attributes);

        services.AddLogging(configure => configure.AddOpenTelemetry(options => options.SetResourceBuilder(resourceBuilder).AddOtlpExporter()));

        services.AddOpenTelemetry()
            .WithTracing(tracing => tracing
                .SetResourceBuilder(resourceBuilder)
                .SetSampler(new AlwaysOnSampler())
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter())
            .WithMetrics(metrics => metrics
                .SetResourceBuilder(resourceBuilder)
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter())
                ;

        var tags = attributes.Select(attribute => new KeyValuePair<string, object?>(attribute.Key, attribute.Value));

        services.AddSingleton(new ActivitySource(serviceName, serviceVersion, tags));

        return services;
    }
}
