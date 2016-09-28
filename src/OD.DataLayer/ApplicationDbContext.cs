using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using SGE.Framework.Domain.Entities.Contracts;
using SGE.Framework.Domain.Uow.Contracts;
using SGE.Framework.Extension;
using SGE.Framework.Logging.Audit.Contracts;

namespace OD.DataLayer
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IConfigurationRoot _configuration;
        public ApplicationDbContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _configuration["ConnectionStrings:ApplicationDbConnection"]
                    , serverDbContextOptionsBuilder =>
                    {
                        var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                        serverDbContextOptionsBuilder.CommandTimeout(minutes);
                    }
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        #region UnitOfWork

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().RemoveRange(entities);
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Modified; // Or use ---> this.Update(entity);
        }

        public void ExecuteSqlCommand(string query)
        {
            base.Database.ExecuteSqlCommand(query);
        }

        public void ExecuteSqlCommand(string query, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(query, parameters);
        }

        public int SaveAllChanges()
        {
            ApplyAuditConcepts();
            return base.SaveChanges();
        }

        public Task<int> SaveAllChangesAsync()
        {
            ApplyAuditConcepts();
            return base.SaveChangesAsync();
        }

        #endregion UnitOfWork

        #region UpdateAuditFields

        protected virtual void ApplyAuditConcepts()
        {
            var userId = GetAuditUserId();

            var entries = this.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        SetCreationAuditProperties(entry.Entity, userId);

                        break;

                    case EntityState.Modified:
                        SetModificationAuditProperties(entry, userId);
                        if (entry.Entity is ISoftDelete && entry.Entity.As<ISoftDelete>().IsDeleted)
                        {
                            SetDeletionAuditProperties(entry.Entity, userId);
                        }

                        break;

                    case EntityState.Deleted:
                        CancelDeletionForSoftDelete(entry);
                        SetDeletionAuditProperties(entry.Entity, userId);

                        break;

                    case EntityState.Detached:
                        break;

                    case EntityState.Unchanged:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected virtual void SetCreationAuditProperties(object entityAsObj, Guid? userId)
        {
            var entityWithCreationTime = entityAsObj as IHasCreationTime;
            if (entityWithCreationTime == null)
            {
                return;
            }

            if (entityWithCreationTime.CreationTime == default(DateTime))
            {
                entityWithCreationTime.CreationTime = DateTime.Now;
            }

            if (!userId.HasValue || !(entityAsObj is ICreationAudited)) return;
            var entity = entityAsObj as ICreationAudited;
            if (entity.CreatorUserId == null)
            {
                entity.CreatorUserId = userId;
            }
        }

        protected virtual void SetModificationAuditProperties(EntityEntry entry, Guid? userId)
        {
            if (entry.Entity is IHasModificationTime)
            {
                entry.As<IHasModificationTime>().LastModificationTime = DateTime.Now;
            }

            if (entry.Entity is IModificationAudited)
            {
                entry.As<IModificationAudited>().LastModifierUserId = userId;
            }
        }

        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (entry.Entity is ISoftDelete)
            {
                entry.As<ISoftDelete>().IsDeleted = true;
            }
        }

        protected virtual void SetDeletionAuditProperties(object entityAsObj, Guid? userId)
        {
            if (entityAsObj is IHasDeletionTime)
            {
                var entity = entityAsObj.As<IHasDeletionTime>();

                if (entity.DeletionTime == null)
                {
                    entity.DeletionTime = DateTime.Now;
                }
            }

            if (!(entityAsObj is IDeletionAudited)) return;
            {
                var entity = entityAsObj.As<IDeletionAudited>();

                if (entity.DeleterUserId == null)
                    entity.DeleterUserId = userId;
            }
        }

        protected virtual Guid? GetAuditUserId()
        {
            return null;
        }

        #endregion UpdateAuditFields
    }
}
