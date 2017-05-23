using System;

namespace Predica.WebApp.Services.Infrastructure
{
	public interface ITimeService
	{
		DateTime GetDateTimeUtcNow();
	}
}
