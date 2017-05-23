using System;

namespace Predica.WebApp.Data.Entity.Base
{
	public interface IBaseEntitySoftDelete
	{
		DateTime CreationDate { get; set; }
		string CreatorUserObjectIdentifier { get; set; }
		DateTime? LastModificationDate { get; set; }
		string LastModifierUserObjectIdentifier { get; set; }
		bool IsDeleted { get; set; }
		DateTime? DeleteDate { get; set; }
	}
}
