using MvcCORE.Infrastructure.Context;
using MvcCORE.Infrastructure.RepoSitories.Abstract;
using MvcCORE.Infrastructure.RepoSitories.Interface.EntityRepo;
using MvcCORE.Models.Entities.Concrete;

namespace MvcCORE.Infrastructure.RepoSitories.Concrete
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookContext bookContext) : base(bookContext)
        {
        }
    }
}
