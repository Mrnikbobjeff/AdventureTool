using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Realms;

namespace AdventureTool.Repositories.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : RealmObject, IEntity, new()
    {
        public virtual TEntity AddOrUpdate(TEntity item)
        {
            var entity = default(TEntity);

            GetRealmInstance().Write(() =>
            {
                entity = GetRealmInstance().Add(item, update: true);
            });

            return entity;
        }

        public virtual void Delete(string id)
        {
            var item = GetRealmInstance().All<TEntity>().First(i => i.Id == id);

            GetRealmInstance().Write(() => GetRealmInstance().Remove(item));
        }

        public void DeleteAll()
        {
            GetRealmInstance().Write(() => GetRealmInstance().RemoveAll<TEntity>());
        }

        public void DeleteAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var realm = GetRealmInstance();
            realm.Write(() =>
            {
                var itemsToRemove = realm.All<TEntity>().Where(filter).ToList();
                foreach (var item in itemsToRemove)
                {
                    realm.Remove(item);
                }
            });
        }

        public virtual TEntity Get(string id)
        {
            return GetRealmInstance().Find<TEntity>(id);
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return GetRealmInstance().All<TEntity>().Where(predicate);
            }
            return GetRealmInstance().All<TEntity>();
        }

        public virtual void AddOrUpdateAndDeleteMissing(IEnumerable<TEntity> entities, IEnumerable<TEntity> ignoredEntities = null, Func<TEntity, bool> filter = null)
        {
            var realm = GetRealmInstance();
            var removeEntities = realm.All<TEntity>().ToList();

            if (filter != null)
            {
                removeEntities = removeEntities.Where(filter).ToList();
            }

            realm = GetRealmInstance();
            realm.Write(() =>
            {
                removeEntities.RemoveAll(localEntity => entities.Any(remoteEntity => remoteEntity.Id == localEntity.Id));
            });

            if (ignoredEntities != null)
            {
                realm = GetRealmInstance();
                realm.Write(() =>
                {
                    removeEntities.RemoveAll(localEntity => ignoredEntities.Any(ignored => ignored.Id == localEntity.Id));
                });
            }

            foreach (var entity in entities)
            {
                realm = GetRealmInstance();
                realm.Write(() =>
                {
                    GetRealmInstance().Add(entity, true);
                });
            }
            foreach (var entity in removeEntities)
            {
                realm = GetRealmInstance();
                realm.Write(() =>
                {
                    GetRealmInstance().Remove(entity);
                });
            }
        }

        public virtual Realm GetRealmInstance()
        {
            return Realm.GetInstance(GetRealmConfiguration());
        }

        public virtual RealmConfiguration GetRealmConfiguration(string path = "")
        {
            return new RealmConfiguration(path);
        }
    }
}
