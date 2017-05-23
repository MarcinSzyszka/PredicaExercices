using Microsoft.AspNetCore.Http;

namespace Predica.WebApp.Services.Infrastructure
{
	public class UserService : IUserService
	{
		private const string UserObjectIdentifierClaimName = "http://schemas.microsoft.com/identity/claims/objectidentifier";
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string GetUserIdentifier()
		{
			return _httpContextAccessor?.HttpContext?.User?.FindFirst(UserObjectIdentifierClaimName)?.Value;
		}
	}
}
