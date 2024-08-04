using Asp.Versioning;

namespace MyBGList;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection serviceCollection)
    {
        //Add Api Versioning
        serviceCollection.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        return serviceCollection;
    }
}