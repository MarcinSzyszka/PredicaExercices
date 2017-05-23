using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Predica.WebApp.Data.Entity.Base;

namespace Predica.WebApp.Data.Entity
{
	public class Journey : BaseEntitySoftDelete<Guid>
	{
		[Required]
		public string Destination { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		public string Description { get; set; }
		[Required]
		public Enums.TransportMode TransportModeId { get; set; }
		[ForeignKey("TransportModeId")]
		public TransportMode TransportMode { get; set; }
		[Required]
		public string TravelerObjectIdentifier { get; set; }
	}
}
