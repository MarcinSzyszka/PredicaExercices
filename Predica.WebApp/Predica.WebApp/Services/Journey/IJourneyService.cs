using System;
using System.Collections.Generic;
using Predica.WebApp.ViewModels;

namespace Predica.WebApp.Services.Journey
{
	public interface IJourneyService
	{
		IEnumerable<JourneyViewModel> GetAllUserJourneys();
		JourneyViewModel AddJourney(JourneyViewModel model);
		JourneyViewModel GetById(Guid journeyId);
		JourneyViewModel UpdateJourney(JourneyViewModel model);
		void DeleteJourney(Guid journeyId);
	}
}
