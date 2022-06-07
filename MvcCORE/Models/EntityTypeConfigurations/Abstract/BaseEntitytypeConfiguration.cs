using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCORE.Models.Entities.Abstract;

namespace MvcCORE.Models.EntityTypeConfigurations.Abstract
{
    // IEntityTypeConfiguration bu arayüzü bize teslim edecek olan yapı EFCORE dur bu uygulamada veritabanı kullanacagımız için efcore.sql paketini de 
    // indireceğiz içerisinde zaten efcore geldiği için ekstra olarak bir daha indirmeyeceğiz

    // mic.efcore.sql 3.1.21 (ben sonsürümü indirdim) indirdik bu proje i.in fakat esas önemli olan indirilen paket sürümlerinin versiyonlarıdır
    // //çok çok dikkatli olunmalıdır.
    public abstract class BaseEntitytypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {

        //asp.net projelerinde bu işlemi Constructor içinde yapıyorduk fakat şimdi bu interfaci kullandıgımız için interfacei implamente ederek configurasyonları
        // oluşturucagız..
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //her tablonun bir anahtarı vardır v bu id kolonudur.
            builder.HasKey(a => a.ID);
            builder.Property(a => a.CreatedDate).HasColumnType("datetime2").IsRequired(true);//not null alan
            builder.Property(a => a.DeleteDate).HasColumnType("datetime2").IsRequired(false);
            builder.Property(a => a.UpdateDate).HasColumnType("datetime2").IsRequired(false);
            builder.Property(a => a.status).IsRequired(true);


        }



    }
}
