using System.ComponentModel.DataAnnotations;

namespace MvcCORE.Models.DataTransferObject.AuthorDTO
{
    public class AuthorCreateDTO
    {
        [Required(ErrorMessage ="bu alan boş bırakılamaz")]
        [MinLength(3),MaxLength(35)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        [MinLength(3), MaxLength(35)]
        public string LastName { get; set; }
    }
}
