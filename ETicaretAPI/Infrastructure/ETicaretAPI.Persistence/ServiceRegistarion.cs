using System;
using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;


namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistarion
	{
		public static void AddPersistenceServices(this IServiceCollection services)
        {
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configration.ConnectionString));


			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped< ICustomerWriteRepository,CustomerWriteRepository > ();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped< IOrderWriteRepository, OrderWriteRepository >();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository> ();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepoistory>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();


            services.AddScoped<IProductReadRepository, ProductReadRepository>();
        }
	}
}

