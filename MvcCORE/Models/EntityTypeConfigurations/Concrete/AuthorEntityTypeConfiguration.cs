using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCORE.Models.Entities.Concrete;
using MvcCORE.Models.EntityTypeConfigurations.Abstract;

namespace MvcCORE.Models.EntityTypeConfigurations.Concrete
{
    //Kalıtım Alınan Sınıftaki Configure metodunu VİRTUAL yapitıgımız için burada OVERRİDE edip İçini doldurabiliriz.
    public class AuthorEntityTypeConfiguration:BaseEntitytypeConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a=>a.LastName).IsRequired(true);
            builder.Property(a=>a.FirstName).IsRequired(true);
            base.Configure(builder);
        }

    }
}
