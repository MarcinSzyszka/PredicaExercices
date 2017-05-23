using System.Collections.Generic;

namespace Predica.WebApp.Services.TransportMode
{
	public interface ITransportModeService
	{
		IEnumerable<Data.Entity.TransportMode> GetAllTransportModes();
	}
}
