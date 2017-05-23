using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Predica.WebApp.Data.Entity;

namespace Predica.WebApp.Mappings
{
	public class TransportModeProfile : Profile
	{
		public TransportModeProfile()
		{
			CreateMap<TransportMode, SelectListItem>()
				.ForMember(dest => dest.Text, opt => opt.MapFrom(p => p.Name))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(p => p.Id.ToString()))
				.ForAllOtherMembers(opt => opt.Ignore());
		}
	}
}
