using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Document is required.")]
        [Range(1, 9999)]
        [DisplayName("Document")]
        public int Description { get; set; }
    }
}
