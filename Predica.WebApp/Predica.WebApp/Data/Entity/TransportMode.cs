using Predica.WebApp.Data.Entity.Base;
namespace Predica.WebApp.Data.Entity
{
	public class TransportMode : BaseEntity<Enums.TransportMode>
	{
		public Enums.TransportMode Id { get; set; }
		public string Name { get; set; }
	}
}