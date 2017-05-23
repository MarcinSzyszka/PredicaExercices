using System;
using System.ComponentModel.DataAnnotations;

namespace Predica.WebApp.ViewModels
{
	public class JourneyViewModel
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Destination is required", AllowEmptyStrings = false)]
		[Display(Name = nameof(Destination))]
		public string Destination { get; set; }
		[Display(Name = nameof(Description))]
		public string Description { get; set; }
		[Required(ErrorMessage = "StartDate is required")]
		[Display(Name = nameof(StartDate))]
		[DataType(DataType.DateTime)]
		public DateTime? StartDate { get; set; }
		[Required(ErrorMessage = "EndDate is required")]
		[Display(Name = nameof(EndDate))]
		[DataType(DataType.DateTime)]
		public DateTime? EndDate { get; set; }
		[Required(ErrorMessage = "TransportMode is required")]
		[Display(Name = "Transport Mode")]
		public Enums.TransportMode TransportModeId { get; set; }
		public string TransportModeName { get; set; }
		public string TravelerObjectIdentifier { get; set; }
	}
}
