using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using OD.DomainClasses.Entities.Common;
using OD.DomainClasses.Entities.Profile;
using OD.DomainClasses.Entities.Project;
using OD.DomainClasses.Entities.UM;
using SGE.Framework.Domain.Entities.Contracts;
using SGE.Framework.Domain.Uow.Contracts;
using SGE.Framework.Extension;
using SGE.Framework.Logging.Audit.Contracts;

namespace OD.DataLayer
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        #region DbSets

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<EducationDegree> EducationDegrees { get; set; }
        public virtual DbSet<EducationPlace> EducationPlaces { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Hobby> Hobies { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileFavorite> ProfileFavorites { get; set; }
        public virtual DbSet<ProfileHobby> ProfileHobbies { get; set; }
        public virtual DbSet<ProfileProject> ProfileProjects { get; set; }
        public virtual DbSet<ProfileSkill> ProfileSkills { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }

        #endregion

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

        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
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
                        if (entry.Entity is IApproverAudited)
                        {
                            SetDeletionAuditProperties(entry.Entity, userId);
                        }

                        break;

                    case EntityState.Deleted:
                        CancelDeletionForSoftDelete(entry);
                        SetApprovedAuditProperties(entry, userId);

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

        protected virtual void SetApprovedAuditProperties(EntityEntry entry, Guid? userId)
        {
            if (entry.Entity is IHasApproveTime)
            {
                entry.As<IHasApproveTime>().ApproveTime = DateTime.Now;
            }

            if (entry.Entity is IApproverOfTUserAudited)
            {
                entry.As<IApproverOfTUserAudited>().LastApproverUserId = userId;
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
            if (!(entry.Entity is ISoftDelete)) return;
            var softDelete = (ISoftDelete)entry.Entity;
            entry.State = EntityState.Unchanged;
            softDelete.IsDeleted = true;
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
