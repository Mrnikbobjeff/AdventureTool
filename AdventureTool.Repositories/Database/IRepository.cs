using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Realms;

namespace AdventureTool.Repositories.Database
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Get(string id);
        TEntity AddOrUpdate(TEntity item);
        void Delete(string id);
        void DeleteAll();
        void DeleteAll(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        void AddOrUpdateAndDeleteMissing(IEnumerable<TEntity> entities, IEnumerable<TEntity> ignoreEntities = null, Func<TEntity, bool> filter = null);

        Realm GetRealmInstance();
        RealmConfiguration GetRealmConfiguration(string path = "");
    }
}
