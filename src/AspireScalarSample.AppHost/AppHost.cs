using Projects;
using Scalar.Aspire;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var api = builder.AddProject<AspireScalarSample_Api>("api");
        
        builder
            .AddScalarApiReference(opts =>
                opts.WithTheme(ScalarTheme.BluePlanet)
                    .WithDefaultHttpClient(ScalarTarget.Shell, ScalarClient.Curl)
            ).WithApiReference(api);

        builder.Build().Run();
    }
}