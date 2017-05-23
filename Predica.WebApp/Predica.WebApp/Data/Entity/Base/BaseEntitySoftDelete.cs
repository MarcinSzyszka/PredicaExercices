using System;
using System.ComponentModel.DataAnnotations;

namespace Predica.WebApp.Data.Entity.Base
{
	public abstract class BaseEntitySoftDelete<TPrimaryKey> : BaseEntity<TPrimaryKey>, IBaseEntitySoftDelete
	{
		[Required]
		public DateTime CreationDate { get; set; }
		[Required]
		public string CreatorUserObjectIdentifier { get; set; }
		public DateTime? LastModificationDate { get; set; }
		public string LastModifierUserObjectIdentifier { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeleteDate { get; set; }
		
	}
}
