using System;
using Xunit;
using ExpectedObjects;
using Almoxarifado.Domain.Builders;
using Almoxarifado.Domain;
using Bogus;

namespace Almoxarifado.Test
{
    public class CategoriaTest
    {
        private string _nome;
        private string _descricao;

        public CategoriaTest()
        {
            Faker faker = new Faker();
            faker.Locale = "pt_BR";
            _nome = faker.Name.FirstName();
            _descricao = faker.Random.Words(5);
        }

        [Fact]
        public void DeveCriarCategoriaComSucesso()
        {
            // Arrange
            var categoriaEsperada = new
            {
                Nome = _nome,
                Descricao = _descricao
            };

            // Act
            Categoria categoriaCriada = new Categoria(
                categoriaEsperada.Nome,
                categoriaEsperada.Descricao
            );

            // Assert
            categoriaEsperada.ToExpectedObject().ShouldMatch(categoriaCriada);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CategoriaNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(() => new CategoriaBuilder().SetNome(nome).Build());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CategoriaDescricaoInvalida(string descricao)
        {
            Assert.Throws<ArgumentException>(() => new CategoriaBuilder().SetDescricao(descricao).Build());
        }
    }
}
