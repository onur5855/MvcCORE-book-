using MvcCORE.Infrastructure.Context;
using MvcCORE.Infrastructure.RepoSitories.Abstract;
using MvcCORE.Infrastructure.RepoSitories.Interface.EntityRepo;
using MvcCORE.Models.Entities.Concrete;

namespace MvcCORE.Infrastructure.RepoSitories.Concrete
{
    public class DetailsRepository : BaseRepository<Details>, IDetailsRepository
    {
        public DetailsRepository(BookContext bookContext) : base(bookContext)
        {
        }
    }
}
