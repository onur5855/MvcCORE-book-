using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCORE.Models.Entities.Concrete;
using MvcCORE.Models.EntityTypeConfigurations.Abstract;

namespace MvcCORE.Models.EntityTypeConfigurations.Concrete
{
    public class DetailsEntityTypeConfiguration:BaseEntitytypeConfiguration<Details>
    {
        public override void Configure(EntityTypeBuilder<Details> builder)
        {
            builder.Property(a => a.Summary).IsRequired(true);
            builder.Property(a=>a.Description).IsRequired(true);
            //1 detayın 1 kitabı vardır ve bunlar detaildID ile baglantılıdır..
            builder.HasOne(a=>a.DetailBook).WithOne(a=>a.BookDetails).HasForeignKey<Book>(a=>a.DetailsID);
            base.Configure(builder);
        }
    }
}
