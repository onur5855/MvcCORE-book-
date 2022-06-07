using MvcCORE.Models.Entities.Abstract;

namespace MvcCORE.Models.Entities.Concrete
{
    public class Author:BaseEntity
    {
        public Author()
        {
            AuthorBooks = new List<Book>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override string ToString()
        {
            return FirstName + " " +LastName;
        }
        //navigationProprty
        // 1 yazarın çokça kitabı  vardır
        public virtual List<Book> AuthorBooks { get; set; }



    }
}
