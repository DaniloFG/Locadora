using FluentAssertions;
using Locadora.Domain.Entities;
using Locadora.Domain.Validation;
using System;
using Xunit;

namespace Locadora.Domain.Test
{
    public class ClientUnitTest
    {
        [Fact]
        public void CreateClient_WithValidParameters()
        {
            Action action = () => new Client(1, "Client Name", 123546);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateClient_NegativeIdValue()
        {
            Action action = () => new Client(-1, "Client Name", 123546);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id.");
        }

        [Fact]
        public void CreateClient_NegativeDocumentValue()
        {
            Action action = () => new Client(1, "Client Name", -1);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid document.");
        }

        [Fact]
        public void CreateClient_ShortNameValue()
        {
            Action action = () => new Client(1, "Cl", 123546);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateClient_MissingNameValue()
        {
            Action action = () => new Client(1, "", 123546);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateClient_WithNullNameValue()
        {
            Action action = () => new Client(1, null, 123456);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
