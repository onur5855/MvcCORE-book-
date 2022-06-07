using MvcCORE.Models.Entities.Abstract;

namespace MvcCORE.Models.Entities.Concrete
{
    public class Details:BaseEntity
    {
        public string Description { get; set; }//açıklama

        public string Summary { get; set; }// özet

        // navigationProp
        //1 detayin 1 kitabı olur (one to one)
        //birebir  ilişkili olunan entityni id ve nesnesi tutulur.

        public int BookID { get; set; }
        public virtual Book DetailBook { get; set; }

    }
}
