﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Utilities.IoC
{
    public static class ServiceTool
    {
public static IServiceProvider ServiceProvider { get; set; }

public static IServiceCollection Create(IServiceCollection services)
{
    ServiceProvider = services.BuildServiceProvider();
    return services;
}
    }
}
