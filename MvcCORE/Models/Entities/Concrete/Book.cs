using MvcCORE.Models.Entities.Abstract;

namespace MvcCORE.Models.Entities.Concrete
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int PageNumber { get; set; }

        //NavigationProp
        //1 kitabın 1 detayı
        public int DetailsID { get; set; }
        public virtual Details BookDetails { get; set; }


        //1 kitabın 1 yazarı vardır.
        //1 e çok ilişkilerde çok olan tarafta tek olanın id si yani kitap içerisinde yazarın id si yani kitap içerisinde yazarın id si olmaldıır

        public int AuthorID { get; set; }

        public virtual Author BookAuthor { get; set; }


    }
}