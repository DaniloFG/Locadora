using Locadora.Domain.Validation;
using System;

namespace Locadora.Domain.Entities
{
    public sealed class Rent : Entity
    {        
        public DateTime DateWithdrawal { get; set; } = DateTime.Now;
        public DateTime DateDevolution { get; set; }
        public DateTime DateDelivery { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Rent(DateTime dateWithdrawal, DateTime dateDevolution, DateTime dateDelivery)
        {
            DateWithdrawal = dateWithdrawal;
            DateDevolution = dateDevolution;
            DateDelivery = dateDelivery;
        }

        public Rent(int id, DateTime dateWithdrawal, DateTime dateDevolution, DateTime dateDelivery)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id.");

            Id = id;
            DateWithdrawal = dateWithdrawal;
            DateDevolution = dateDevolution;
            DateDelivery = dateDelivery;
        }
    }
}
