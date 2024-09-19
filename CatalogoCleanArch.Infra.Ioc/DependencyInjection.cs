using CatalogoCleanArch.Application.Interfaces;
using CatalogoCleanArch.Application.Mappings;
using CatalogoCleanArch.Application.Services;
using CatalogoCleanArch.Domain.Interfaces;
using CatalogoCleanArch.Infra.Data.Context;
using CatalogoCleanArch.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCleanArch.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
        );

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("CatalogoCleanArch.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myhandlers));

        return services;
    }
}
