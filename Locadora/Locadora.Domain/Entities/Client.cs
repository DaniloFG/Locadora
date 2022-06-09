using Locadora.Domain.Validation;
using System.Collections.Generic;

namespace Locadora.Domain.Entities
{
    public sealed class Client : Entity
    {
        public string Name { get; private set; }
        public int Document { get; private set; }

        public ICollection<Rent> Rent { get; set; }

        public Client(string name, int document)
        {
            Validate(name, document);
        }

        public Client(int id, string name, int document)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id.");
            
            Id = id;
            
            Validate(name, document);
        }

        private void Validate(string name, int document)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(document < 0, "Invalid document.");

            Name = name;
            Document = document;
        }
    }
}
