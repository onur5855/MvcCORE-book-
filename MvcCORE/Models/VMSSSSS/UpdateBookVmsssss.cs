using System.ComponentModel.DataAnnotations;

namespace MvcCORE.Models.VMSSSSS
{
    public class UpdateBookVmsssss
    {
        public int ID { get; set; }
        [Required]
        [MinLength(5), MaxLength(55)]
        public string Name { get; set; }
        [Required]
        [MinLength(5), MaxLength(55)]
        public string Description { get; set; }
        [Required]
        public int PageNumber { get; set; }

        //details
        [Required]
        [MinLength(5), MaxLength(55)]
        public string DetailDescription { get; set; }//açıklama
        [Required]
        [MinLength(5), MaxLength(55)]
        public string Summary { get; set; }// özet
        //Authorr
        [Required]
        public int AuthorID { get; set; }


    }
}
