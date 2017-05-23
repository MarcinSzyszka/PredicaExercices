using System;

namespace Predica.WebApp.Services.Infrastructure
{
	public class TimeService : ITimeService
	{
		public DateTime GetDateTimeUtcNow()
		{
			return DateTime.UtcNow;
		}
	}
}
