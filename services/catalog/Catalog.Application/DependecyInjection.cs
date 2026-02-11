using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public static class DependecyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
		return services;
	}
}