using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCORE.Models.Entities.Concrete;
using MvcCORE.Models.EntityTypeConfigurations.Abstract;

namespace MvcCORE.Models.EntityTypeConfigurations.Concrete
{
    public class BookEntityTypeConfiguration:BaseEntitytypeConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(90).IsRequired(true);
            builder.Property(a => a.Description).HasMaxLength(150).IsRequired(true);
            // birebir ilişkiyi 2. kez yazdık nasıl yazildiğini görmek için diğer taraftan bakınca bu şekilde yazıldıgını anla diye :S

            builder.HasOne(a => a.BookDetails).WithOne(a => a.DetailBook).HasForeignKey<Details>(a => a.BookID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            //deleteBehavior => silinme davranışı cascade olan ilişkili nesnelerde biri silindiğinde diğeride silinsin 
            //Noactıon => biri silindiğinde diğeri kalsın birşey yapma.
            builder.HasOne(a => a.BookAuthor).WithMany(a => a.AuthorBooks).HasForeignKey(a => a.AuthorID);
            
            base.Configure(builder);
        }
    }
}
