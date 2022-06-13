using Locadora.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Locadora.Application.DTOs
{
    public class RentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date withdrawal is required.")]
        [DisplayName("Date withdrawal")]
        public DateTime DateWithdrawal { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Date devolution is required.")]
        [DisplayName("Date devolution")]
        public DateTime DateDevolution { get; set; }

        [Required(ErrorMessage = "Date delivery is required.")]
        [DisplayName("Date delivery")]
        public DateTime DateDelivery { get; set; }

        [DisplayName("Films")]
        public int FilmId { get; set; }
        
        [JsonIgnore]
        public Film Film { get; set; }

        [DisplayName("Clients")]
        public int ClientId { get; set; }
        
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
