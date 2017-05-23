using Microsoft.Extensions.DependencyInjection;
using NonFactors.Mvc.Grid;
using Predica.WebApp.Services.Infrastructure;
using Predica.WebApp.Services.Journey;
using Predica.WebApp.Services.TransportMode;

namespace Predica.WebApp.Startup
{
	public partial class Startup
	{
		public void AddCustomServices(IServiceCollection services)
		{
			services.AddMvcGrid();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ITimeService, TimeService>();
			services.AddScoped<IJourneyService, JourneyService>();
			services.AddScoped<ITransportModeService, TransportModeService>();
		}

	}
}
