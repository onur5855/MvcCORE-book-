using System.ComponentModel.DataAnnotations;

namespace MvcCORE.Models.DataTransferObject.AuthorDTO
{
    public class AuthorUpdateDTO
    {
        public int ID { get; set; }


        [Required(ErrorMessage ="bu alan boş gecilemez")]
        [MinLength(3),MaxLength(30)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "bu alan boş gecilemez")]
        [MinLength(3), MaxLength(30)]
        public string FirstName { get; set; }

    }
}
