using MvcCORE.Infrastructure.Context;
using MvcCORE.Infrastructure.RepoSitories.Abstract;
using MvcCORE.Infrastructure.RepoSitories.Interface.EntityRepo;
using MvcCORE.Models.Entities.Concrete;

namespace MvcCORE.Infrastructure.RepoSitories.Concrete
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookContext bookContext) : base(bookContext)
        {
        }
    }
}
