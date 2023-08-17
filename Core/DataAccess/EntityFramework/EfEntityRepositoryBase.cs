using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // using bitince garbage collector'e beni at diyor buda performansı etkiler
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakalama
                addedEntity.State = EntityState.Added; //ekliceğimizi belirtiyoruz
                context.SaveChanges(); //işlemi veritabnına işliyor
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //referansı yakalama
                deletedEntity.State = EntityState.Deleted; //ekliceğimizi belirtiyoruz
                context.SaveChanges(); //işlemi veritabnına işliyor
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // filtreye göre 1 tane ürün döndürür
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null  //ternary fonksiyonu yazıyoruz
                ? context.Set<TEntity>().ToList()  //filtre null ise tüm ürünleri getir
                    : context.Set<TEntity>().Where(filter).ToList();  //filtre varsa filtre'ye göre eşleşen ürünleri getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //referansı yakalama
                updatedEntity.State = EntityState.Modified; //ekliceğimizi belirtiyoruz
                context.SaveChanges(); //işlemi veritabnına işliyor
            }
        }
    }
}
