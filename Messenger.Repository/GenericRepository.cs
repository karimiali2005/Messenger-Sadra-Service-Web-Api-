using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Messenger.DAL;

namespace Messenger.Repository
{
    /// <summary>
    /// Generic repository
    /// </summary>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly string _connectionStringName;
        private DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TEntity&gt;"/> class.
        /// </summary>
        public GenericRepository()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        public GenericRepository(string connectionStringName)
        {
            this._connectionStringName = @"data source=PC\SQLEXPRESS;initial catalog=TaskManager;user id=sa;password=123;MultipleActiveResultSets=True;";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
        }

        public GenericRepository(ObjectContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = new DbContext(context, true);
        }

        public TEntity GetByKey(object keyValue)
        {
            EntityKey key = GetEntityKey(keyValue);

            object originalItem;
            if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }

        public IQueryable<TEntity> GetQuery()
        {
            /* 
             * From CTP4, I could always safely call this to return an IQueryable on DbContext 
             * then performed any with it without any problem:
             */
            // return DbContext.Set<TEntity>();

            /*
             * but with 4.1 release, when I call GetQuery<TEntity>().AsEnumerable(), there is an exception:
             * ... System.ObjectDisposedException : The ObjectContext instance has been disposed and can no longer be used for operations that require a connection.
             */

            // here is a work around: 
            // - cast DbContext to IObjectContextAdapter then get ObjectContext from it
            // - call CreateQuery<TEntity>(entityName) method on the ObjectContext
            // - perform querying on the returning IQueryable, and it works!
            var entityName = GetEntityName();
            return ((IObjectContextAdapter)DbContext).ObjectContext.CreateQuery<TEntity>(entityName);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate) 
        {
            return GetQuery().Where(predicate);
        }

        public IQueryable<TEntity> GetQuery(ISpecification<TEntity> criteria)
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery());
        }

        public IEnumerable<TEntity> Get<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return GetQuery().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return GetQuery().OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<TEntity> Get< TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return GetQuery(criteria).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return GetQuery(criteria).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<TEntity> Get< TOrderBy>(ISpecification<TEntity> specification, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return specification.SatisfyingEntitiesFrom(GetQuery()).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return specification.SatisfyingEntitiesFrom(GetQuery()).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
        {
            return GetQuery(criteria).AsEnumerable();
        }
        public TEntity Single(Expression<Func<TEntity, bool>> criteria)
        {
            return GetQuery().Single<TEntity>(criteria);
        }

        public TEntity Single(ISpecification<TEntity> criteria)
        {
            return criteria.SatisfyingEntityFrom(GetQuery());
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return GetQuery().FirstOrDefault(predicate);
        }

        public TEntity First(ISpecification<TEntity> criteria)
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery()).First();
        }

        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                DbContext.Set<TEntity>().Add(entity);
                DbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            DbContext.Set<TEntity>().Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> criteria)
        {
            IEnumerable<TEntity> records = Find(criteria);

            foreach (TEntity record in records)
            {
                Delete(record);
            }
        }

        public void Delete(ISpecification<TEntity> criteria)
        {
            IEnumerable<TEntity> records = Find(criteria);
            foreach (TEntity record in records)
            {
                Delete(record);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }

        public TEntity Save(TEntity entity)
        {
            Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            var fqen = GetEntityName();

            object originalItem;
            EntityKey key = ((IObjectContextAdapter)DbContext).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                ((IObjectContextAdapter)DbContext).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
            }
            DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return GetQuery().Where(criteria);
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> criteria)
        {
            return GetQuery().Where(criteria).FirstOrDefault();
        }

        public TEntity FindOne(ISpecification<TEntity> criteria)
        {
            return criteria.SatisfyingEntityFrom(GetQuery());
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> criteria)
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery()).AsEnumerable();
        }

        public int Count()
        {
            return GetQuery().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> criteria) 
        {
            return GetQuery().Count(criteria);
        }

        public int Count(ISpecification<TEntity> criteria) 
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery()).Count();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(this.DbContext);
                }
                return unitOfWork;
            }
        }

        private EntityKey GetEntityKey(object keyValue) 
        {
            var entitySetName = GetEntityName();
            var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<TEntity>();
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }

        private string GetEntityName()
        {
            // PluralizationService pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
            // return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, pluralizer.Pluralize(typeof(TEntity).Name));

            // Thanks to Kamyar Paykhan -  http://huyrua.wordpress.com/2011/04/13/entity-framework-4-poco-repository-and-specification-pattern-upgraded-to-ef-4-1/#comment-688
            string entitySetName = ((IObjectContextAdapter)DbContext).ObjectContext
                .MetadataWorkspace
                .GetEntityContainer(((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, DataSpace.CSpace)
                                    .BaseEntitySets.Where(bes => bes.ElementType.Name == typeof(TEntity).Name).First().Name;
            return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, entitySetName);
        }

        public DbContext DbContext
        {
            get
            {
                if (this._context == null)
                {
                        this._context = new MessengerContext();
                }
                this._context.Configuration.ProxyCreationEnabled = false;
                return this._context;
            }
        }

        private IUnitOfWork unitOfWork;

        public void RefreshEntity()
        {
            var entityType = typeof (TEntity);
            
            //https://christianarg.wordpress.com/2013/06/13/entityframework-refreshall-loaded-entities-from-database/
            var objectContext = ((IObjectContextAdapter)DbContext).ObjectContext;
            var refreshableObjects = objectContext.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged)
                .Where(x => entityType == null || x.Entity.GetType() == entityType)
                .Where(entry => entry.EntityKey != null)
                .Select(e => e.Entity)
                .ToArray();

            objectContext.Refresh(RefreshMode.StoreWins, refreshableObjects);

        }

    }
}
