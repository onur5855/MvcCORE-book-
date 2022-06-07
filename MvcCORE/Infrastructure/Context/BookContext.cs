using Microsoft.EntityFrameworkCore;
using MvcCORE.Models.Entities.Concrete;
using MvcCORE.Models.EntityTypeConfigurations.Concrete;

namespace MvcCORE.Infrastructure.Context
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {
            //.net de burada connectionstringimizi yazıyorduk ama artık burada yazamayacagız.
            // asp.net core bizi devamlı DI(Dependency Injection) yapmaya zorlar burada da bunu yapıyoruz. BOOKCONTEXT uygulama içinde herhangi bir yerde
            //Inject edildiğinde kullanıma hazırlanırken startup dosyası içindeki options yani özellikleri kullanılarak base e iletir.
            //core da farklı veritabanları ile çalışma  ihtimalide düşünüldüğünden constr imizi appsetting.json da yazacagız ve starup içinde registr
            //(kayıt) etmiş olacagız
        }
        public DbSet<Book> books{ get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Details> details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetailsEntityTypeConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
