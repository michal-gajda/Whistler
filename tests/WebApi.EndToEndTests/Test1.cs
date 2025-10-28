namespace Whistler.WebApi.EndToEndTests;

using Microsoft.AspNetCore.Mvc.Testing;
using Whistler.WebApi;

[TestClass]
public sealed class Test1
{
    private static WebApplicationFactory<Program>? factory;

    [ClassInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
        factory = new WebApplicationFactory<Program>();
    }

    [ClassCleanup(ClassCleanupBehavior.EndOfClass)]
    public static void AssemblyCleanup()
    {
        factory!.Dispose();
    }

    [TestMethod]
    [DataRow("/WeatherForecast")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory!.CreateClient();

        // Act
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType!.ToString().ShouldBe("application/json; charset=utf-8");
    }
}
