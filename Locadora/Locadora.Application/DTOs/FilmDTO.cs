using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Invalid stock.")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }
    }
}
