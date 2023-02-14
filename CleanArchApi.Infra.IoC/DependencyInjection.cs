using CleanArchApi.Application.Interfaces;
using CleanArchApi.Application.Mappings;
using CleanArchApi.Application.Services;
using CleanArchApi.Domain.Auth;
using CleanArchApi.Domain.Interfaces;
using CleanArchApi.Infra.Context;
using CleanArchApi.Infra.Identity;
using CleanArchApi.Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchApi.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
            migrat => migrat.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthenticate, AuthenticateUser>();

        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EntityToDTOMappingProfile));

        return services;
    }

    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        var handler = AppDomain.CurrentDomain.Load("CleanArchApi.Application");
        services.AddMediatR(handler);

        return services;
    }
}
