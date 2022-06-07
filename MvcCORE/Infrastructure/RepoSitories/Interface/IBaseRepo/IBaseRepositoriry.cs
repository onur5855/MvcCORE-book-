using MvcCORE.Models.Entities.Abstract;
using System.Linq.Expressions;

namespace MvcCORE.Infrastructure.RepoSitories.Interface.IBaseRepo
{
    public interface IBaseRepositoriry<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetDefault(Expression<Func<T,bool>> expression);// tek bir T tipi aldıgı sorguya bağlı döner
        List<T> GetDefaults(Expression<Func<T, bool>> expression);//bütün  T tiplerini aldıgı expression yani sorguya bağlı olarak döner
    }
}
