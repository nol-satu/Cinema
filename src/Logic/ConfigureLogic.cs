﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Logic;

public static class ConfigureLogic
{
    public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddMediatR(configuration =>
        {
            _ = configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddDataAccess(configuration);

        return services;
    }
}
