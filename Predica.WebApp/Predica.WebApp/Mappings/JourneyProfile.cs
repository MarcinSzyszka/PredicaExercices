using AutoMapper;
using Predica.WebApp.Data.Entity;
using Predica.WebApp.ViewModels;

namespace Predica.WebApp.Mappings
{
    public class JourneyProfile : Profile
	{
		public JourneyProfile()
		{
			CreateMap<Journey, JourneyViewModel>();
			CreateMap<JourneyViewModel, Journey>()
				.ForMember(dest => dest.CreationDate, opt => opt.Ignore())
				.ForMember(dest => dest.CreatorUserObjectIdentifier, opt => opt.Ignore())
				.ForMember(dest => dest.DeleteDate, opt => opt.Ignore())
				.ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
		}
    }
}
