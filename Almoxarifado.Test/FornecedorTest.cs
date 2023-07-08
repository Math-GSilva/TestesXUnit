using System;
using Xunit;
using ExpectedObjects;
using Almoxarifado.Domain.Builders;
using Almoxarifado.Domain;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Almoxarifado.Test
{
    public class FornecedorTest
    {
        private string _documento;
        private string _nome;
        private DateTime _dataNasc;
        private string _nomeFantasia;

        public FornecedorTest()
        {
            Faker faker = new Faker();
            faker.Locale = "pt_BR ";
            _documento = faker.Company.Cnpj(false);
            _nome = faker.Name.FullName();
            _dataNasc = faker.Date.Between(DateTime.MinValue, DateTime.Now.AddYears(-18));
            _nomeFantasia = faker.Company.Bs();
        }

        [Fact]
        public void DeveCriarFornecedorComSucesso()
        {
            // Arrange
            var fornecedorEsperado = new
            {
                Documento = _documento,
                Nome = _nome,
                DataNasc = _dataNasc,
                NomeFantasia = _nomeFantasia
            };

            // Act
            Fornecedor fornecedorCriado = new Fornecedor(
                fornecedorEsperado.Documento,
                fornecedorEsperado.Nome,
                fornecedorEsperado.DataNasc,
                fornecedorEsperado.NomeFantasia
            );

            // Assert
            fornecedorEsperado.ToExpectedObject().ShouldMatch(fornecedorCriado);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void FornecedorNomeFantasiaInvalido(string nomeFantasia)
        {
            Assert.Throws<ArgumentException>(() => new FornecedorBuilder().SetNomeFantasia(nomeFantasia).Build());
        }
    }
}
