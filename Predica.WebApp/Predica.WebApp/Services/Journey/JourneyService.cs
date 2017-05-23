using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Predica.WebApp.Data.Context;
using Predica.WebApp.Data.Repository;
using Predica.WebApp.Services.Infrastructure;
using Predica.WebApp.ViewModels;

namespace Predica.WebApp.Services.Journey
{
	public class JourneyService : RepositoryBaseSoftDelete<AppDbContext, Data.Entity.Journey, Guid>, IJourneyService
	{
		private readonly IUserService _userService;

		public JourneyService(AppDbContext context, IUserService userService) : base(context)
		{
			_userService = userService;
		}

		public JourneyViewModel GetById(Guid journeyId)
		{
			return Mapper.Map<JourneyViewModel>(GetByEntityId(journeyId));
		}

		public IEnumerable<JourneyViewModel> GetAllJourneys()
		{
			return GetAll()
					.ProjectTo<JourneyViewModel>();
		}

		public IEnumerable<JourneyViewModel> GetAllUserJourneys()
		{
			return GetAll()
				   .Where(j => j.TravelerObjectIdentifier == _userService.GetUserIdentifier())
				   .ProjectTo<JourneyViewModel>();
		}

		public JourneyViewModel AddJourney(JourneyViewModel model)
		{
			model.TravelerObjectIdentifier = _userService.GetUserIdentifier();
			var entity = Mapper.Map<Data.Entity.Journey>(model);
			Insert(entity);
			SaveChanges();

			return Mapper.Map<JourneyViewModel>(entity);
		}

		public JourneyViewModel UpdateJourney(JourneyViewModel model)
		{
			Data.Entity.Journey entityToUpdate = GetAndMap(model);
			Update(entityToUpdate);
			SaveChanges();

			return Mapper.Map<JourneyViewModel>(entityToUpdate);
		}

		public void DeleteJourney(Guid journeyId)
		{
			var entity = GetByEntityId(journeyId);
			Delete(entity);
			SaveChanges();
		}

		private Data.Entity.Journey GetAndMap(JourneyViewModel model)
		{
			//I know, this might seem crazy - mapping from hand when I have AutoMapper in project
			//but I haven't made abstraction of entities and repository as good as I should and also I had to go to the bed ;)
			var entityToUpdate = GetByEntityId(model.Id);
			entityToUpdate.Description = model.Description;
			entityToUpdate.Destination = model.Destination;
			if (model.StartDate != null) entityToUpdate.StartDate = model.StartDate.Value;
			if (model.EndDate != null) entityToUpdate.EndDate = model.EndDate.Value;
			entityToUpdate.TransportModeId = model.TransportModeId;
			return entityToUpdate;
		}
	}
}
