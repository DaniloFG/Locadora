using FluentAssertions;
using Locadora.Domain.Entities;
using Locadora.Domain.Validation;
using System;
using Xunit;

namespace Locadora.Domain.Test
{
    public class FilmUnitTest
    {
        [Fact]
        public void CreateFilm_WithValidParameters()
        {
            Action action = () => new Film(1, "Film Title", 1);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateFilm_NegativeIdValue()
        {
            Action action = () => new Film(-1, "Film Title", 1);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id.");
        }

        [Fact]
        public void CreateFilm_NegativeStockValue()
        {
            Action action = () => new Film(1, "Film Title", -1);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock.");
        }

        [Fact]
        public void CreateFilm_ShortTitleValue()
        {
            Action action = () => new Film(1, "Fi", 1);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid title, too short, minimun 3 characters.");
        }

        [Fact]
        public void CreateFilm_MissingTitleValue()
        {
            Action action = () => new Film(1, "", 1);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid title. Title is required.");
        }

        [Fact]
        public void CreateFilm_WithNullTitleValue()
        {
            Action action = () => new Film(1, null, 1);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
