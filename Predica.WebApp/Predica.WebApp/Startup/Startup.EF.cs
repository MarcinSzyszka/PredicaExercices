using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Predica.WebApp.Data.Context;
using Predica.WebApp.Enums;

namespace Predica.WebApp.Startup
{
	public partial class Startup
	{
		private void AddEntityFramework(IServiceCollection services)
		{
			var a = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		}

		public void MigrateAndSeedDb(AppDbContext appDbContext)
		{
			appDbContext.Database.Migrate();

			if (!appDbContext.TransportMode.Any())
			{
				foreach (var state in Enum.GetValues(typeof(TransportMode)))
				{
					appDbContext.TransportMode.Add(new Data.Entity.TransportMode { Id = (Enums.TransportMode)state, Name = state.ToString() });
				}

				appDbContext.SaveChanges();
			}
		}
	}
}
