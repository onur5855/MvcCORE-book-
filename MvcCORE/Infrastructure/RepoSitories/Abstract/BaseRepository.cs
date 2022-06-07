using Microsoft.EntityFrameworkCore;
using MvcCORE.Infrastructure.Context;
using MvcCORE.Infrastructure.RepoSitories.Interface.IBaseRepo;
using MvcCORE.Models.Entities.Abstract;
using System.Linq.Expressions;
using MvcCORE.Models.Enum;
namespace MvcCORE.Infrastructure.RepoSitories.Abstract

{
    public abstract class BaseRepository<T> : IBaseRepositoriry<T> where T : BaseEntity
    {
        private readonly BookContext bookContext; //readonly sadece okunabilir anlamına gelir
        private readonly DbSet<T> table;

        public BaseRepository(BookContext bookContext)
        {
            this.bookContext = bookContext;
            table=bookContext.Set<T>();
        }

        public void Create(T entity)
        {
           table.Add(entity);
            bookContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.status=Status.Passive;
            entity.DeleteDate = DateTime.Now;
            bookContext.SaveChanges();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return table.FirstOrDefault(expression);
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).ToList();
        }

        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.status=Status.Modified;
            bookContext.SaveChanges();
        }


    }
}
