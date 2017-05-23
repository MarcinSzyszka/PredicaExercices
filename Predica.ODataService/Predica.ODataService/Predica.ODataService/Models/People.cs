namespace Predica.ODataService.Models
{
	public class People : ODataEntityBase
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string[] Emails { get; set; }
	}
}