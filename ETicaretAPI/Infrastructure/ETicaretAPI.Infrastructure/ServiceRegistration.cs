﻿using System;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection sC)
        {
			sC.AddScoped<IFileServices, FileService>();

        }
	}
}

