using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Predica.WebApp.Startup
{
    public partial class Startup
    {
	    public void AddMvc(IServiceCollection services)
	    {
			services.AddMvc(options =>
			{
				options.Filters.Add(typeof(AutoValidateAntiforgeryTokenAuthorizationFilter));
			});
		}

	    public void UseMvc(IApplicationBuilder app)
	    {
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
    }
}
