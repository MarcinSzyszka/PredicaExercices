using System.Collections;
using System.Collections.Generic;
using Predica.WebApp.Data.Context;
using Predica.WebApp.Data.Repository;

namespace Predica.WebApp.Services.TransportMode
{
	public class TransportModeService : RepositoryBase<AppDbContext, Data.Entity.TransportMode, Enums.TransportMode>, ITransportModeService
	{
		public TransportModeService(AppDbContext context) : base(context)
		{
		}

		public IEnumerable<Data.Entity.TransportMode> GetAllTransportModes()
		{
			return GetAll();
		}

	}
}
