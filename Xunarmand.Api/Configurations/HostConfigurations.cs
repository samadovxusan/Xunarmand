namespace Xunarmand.Api.Configurations;

public static partial class  HostConfigurations
{
    public static  ValueTask<WebApplicationBuilder> ConfigureAsnyc(this WebApplicationBuilder builder)
    {
        builder
            .AddMappers()
            .AddValidators()   
            .AddPersistence()
            .AddIdentityInfrastructure()
            .AddMediator()
            .AddDevTools()
            .AddExposers();
        return new ValueTask<WebApplicationBuilder>(builder);
    }
    
    public static async ValueTask<WebApplication> ConfigureAsnyc(this WebApplication  app)
    {
        app.UseCors();
        await app.SeedDataAsync();
        app
            .UseDevtools()
            .UseExposers();
        return app; 
    }
    
} 