using Locadora.Domain.Validation;
using System.Collections.Generic;

namespace Locadora.Domain.Entities
{
    public sealed class Film : Entity
    {

        public string Title { get; private set; }
        public int Stock { get; private set; }

        public ICollection<Rent> Rent { get; set; }

        public Film(string title, int stock)
        {
            Validate(title, stock);
        }

        public Film(int id, string title, int stock)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id.");

            Id = id;

            Validate(title, stock);
        }

        private void Validate(string title, int stock)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "Invalid title. Title is required.");

            DomainExceptionValidation.When(title.Length < 3 , "Invalid title, too short, minimun 3 characters.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock.");

            Title = title;
            Stock = stock;
        }
    }
}
