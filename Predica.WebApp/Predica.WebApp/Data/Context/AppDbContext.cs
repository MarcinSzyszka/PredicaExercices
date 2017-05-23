using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Predica.WebApp.Data.Entity;
using Predica.WebApp.Data.Entity.Base;
using Predica.WebApp.Services.Infrastructure;

namespace Predica.WebApp.Data.Context
{
	public class AppDbContext : DbContext
	{
		private readonly IServiceProvider _serviceProvider;
		public DbSet<Journey> Journey { get; set; }
		public DbSet<TransportMode> TransportMode { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider serviceProvider) : base(options)
		{
			_serviceProvider = serviceProvider;
		}

		public override int SaveChanges()
		{
			var entries = ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();
			if (entries.Count == 0)
			{
				return 0;
			}

			var timeService = (ITimeService)_serviceProvider.GetService(typeof(ITimeService));
			var userService = (IUserService)_serviceProvider.GetService(typeof(IUserService));
			var dateTime = timeService.GetDateTimeUtcNow();
			var user = userService.GetUserIdentifier();

			foreach (var entry in entries)
			{
				switch (entry.State)
				{
					case EntityState.Added:
						SetCreationProperties(entry, dateTime, user);
						break;

					case EntityState.Modified:
						SetModificationAuditProperties(entry, dateTime, user);

						break;

					case EntityState.Deleted:
						SetDeletionProperties(entry, dateTime, user);

						break;
				}
			}

			return base.SaveChanges();
		}

		private void SetDeletionProperties(EntityEntry entry, DateTime dateTime, string user)
		{
			if (entry.Entity is IBaseEntitySoftDelete)
			{
				var entity = (IBaseEntitySoftDelete)entry.Entity;
				entity.DeleteDate = dateTime;
				entity.IsDeleted = true;
				entry.State = EntityState.Modified;
			}
		}

		private void SetModificationAuditProperties(EntityEntry entry, DateTime dateTime, string user)
		{
			if (entry.Entity is IBaseEntitySoftDelete)
			{
				var entity = (IBaseEntitySoftDelete)entry.Entity;
				entity.LastModificationDate = dateTime;
				entity.LastModifierUserObjectIdentifier = user;
			}
		}

		private void SetCreationProperties(EntityEntry entry, DateTime dateTime, string user)
		{
			if (entry.Entity is IBaseEntitySoftDelete)
			{
				var entity = (IBaseEntitySoftDelete)entry.Entity;
				entity.CreationDate = dateTime;
				entity.CreatorUserObjectIdentifier = user;
			}
		}
	}
}
