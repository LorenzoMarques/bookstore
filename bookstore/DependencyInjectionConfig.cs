using bookstore.Mappings;
using bookstore.Repositories;
using bookstore.Services;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddRepositories()
            .AddAuthComponents()
            .AddAutoMapper();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<UsersService>();
        services.AddScoped<BooksService>();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<UsersRepository>();
        services.AddScoped<RolesRepository>();
        services.AddScoped<BooksRepository>();
        services.AddScoped<CategoryRepository>();
        services.AddScoped<BookCategoriesRepository>();
        return services;
    }

    private static IServiceCollection AddAuthComponents(this IServiceCollection services)
    {
        services.AddScoped<JwtService>();
        services.AddScoped<AuthService>();
        return services;
    }

    private static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(BookProfile));
        return services;
    }

}