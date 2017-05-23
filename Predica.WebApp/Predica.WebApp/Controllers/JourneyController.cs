using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Predica.WebApp.Services.Journey;
using Predica.WebApp.Services.TransportMode;
using Predica.WebApp.ViewModels;

namespace Predica.WebApp.Controllers
{
	[Authorize]
	public class JourneyController : Controller
	{
		private readonly IJourneyService _journeyService;
		private readonly ITransportModeService _transportModeService;

		public JourneyController(IJourneyService journeyService, ITransportModeService transportModeService)
		{
			_journeyService = journeyService;
			_transportModeService = transportModeService;
		}

		public IActionResult Index()
		{
			return View(_journeyService.GetAllUserJourneys());
		}

		[Authorize(Roles = "administrator")]
		public IActionResult Administration()
		{
			return View(_journeyService.GetAllUserJourneys());
		}

		public IActionResult Add()
		{
			InitDataForSelectLists();

			return View(new JourneyViewModel());
		}

		[HttpPost]
		public IActionResult Add(JourneyViewModel model)
		{
			if (ModelState.IsValid)
			{
				model = _journeyService.AddJourney(model);

				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		public IActionResult Edit(Guid id)
		{
			InitDataForSelectLists();

			return View(_journeyService.GetById(id));
		}

		[HttpPost]
		public IActionResult Edit(JourneyViewModel model)
		{
			if (ModelState.IsValid)
			{
				model = _journeyService.UpdateJourney(model);

				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}


		public IActionResult Delete(Guid id)
		{
			_journeyService.DeleteJourney(id);

			return RedirectToAction(nameof(Index));
		}

		private void InitDataForSelectLists()
		{
			ViewBag.TransportModes = Mapper.Map<List<SelectListItem>>(_transportModeService.GetAllTransportModes());
		}
	}
}