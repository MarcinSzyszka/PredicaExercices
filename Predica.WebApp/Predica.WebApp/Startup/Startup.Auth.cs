using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Predica.WebApp.Startup
{
	public partial class Startup
	{
		public void AddAuth(IServiceCollection services)
		{
			services.AddAuthentication(sharedOptions => sharedOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
		}

		public void UseOpenIdConnectAuth(IApplicationBuilder app)
		{
			app.UseCookieAuthentication();

			app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
			{
				ClientId = Configuration["Authentication:AzureAd:ClientId"],
				Authority = Configuration["Authentication:AzureAd:AADInstance"] + Configuration["Authentication:AzureAd:TenantId"],
				CallbackPath = Configuration["Authentication:AzureAd:CallbackPath"]
			});
		}
	}
}
